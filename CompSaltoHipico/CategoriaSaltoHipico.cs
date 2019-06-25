
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public abstract class CategoriaSaltoHipico
    {
        List<Recorrido> recorrido;
        List<Binomio> participantes;
        public int TiempoEsperadoRecorrido { get; set; }
        public string Descripcion { get; set; }

        public CategoriaSaltoHipico(int pTiempoEspRecorridoEnSegundos)
        {
            this.recorrido = new List<Recorrido>();
            this.TiempoEsperadoRecorrido = pTiempoEspRecorridoEnSegundos;
            this.participantes = new List<Binomio>();
        }

        public void AddObstaculo(Obstaculo pObstaculo, int pOrden)
        {
            this.recorrido.Add(new Recorrido(this, pObstaculo, pOrden));
        }

        public void AddParticipante(Binomio pBinomio)
        {
            this.participantes.Add(pBinomio);
        }

        public void RegistrarParticipacion(Binomio unBinomio, int unTiempo,
            Dictionary<string, EstadoObstaculoPasado> colObstaculosPasados)
        {
            unBinomio.TiempoEmpleado = unTiempo;

            foreach (var pair in colObstaculosPasados)
            {
                Obstaculo obs = recorrido.Where( w => w.Obstaculo.Id == pair.Key ).FirstOrDefault().Obstaculo;
                                                                        // indica si se paso el obstaculo con exito o falla 
                unBinomio.AddObstaculoPasado( new ObstaculoPasado( obs, pair.Value ) );
            }
        }
        ResultadoParticipante EvaluarParticipante(Binomio pBinomio)
        {
            ResultadoParticipante resultadoParticipante = new ResultadoParticipante();
            resultadoParticipante.Binomio = pBinomio;
            resultadoParticipante.TiempoEmpleado = pBinomio.TiempoEmpleado;

            if (pBinomio.ObstaculosPasados.Count != this.recorrido.Count)
                resultadoParticipante.Descalificado = true; // descalificado por no recorrer todo los OBS

            int k = 0;

            foreach (var rec in this.recorrido.OrderBy(w => w.Orden))
            {
                if (pBinomio.ObstaculosPasados[k].Obstaculo.Id != rec.Obstaculo.Id)
                {
                    resultadoParticipante.Descalificado = true; //  por no seguir el orden los OBS
                    break;
                }

                k++;
            }

            // Los obstáculos pueden ser exigentes o simples. En caso de que un binomio derribe un obstáculo exigente,
            // se considera 3 faltas. Los obstáculos simples al derribarlos sólo determinan 1 falta. 
            List<ObstaculoPasado> obstaculosPasadosConDerribo = 
                pBinomio.ObstaculosPasados.Where(w => w.Estado == EstadoObstaculoPasado.derribo).ToList();

            int faltasXPasoObstaculoExigente = 
                obstaculosPasadosConDerribo.Where( 
                    w => w.Obstaculo.TipoObstaculo == TipoObstaculo.exigente).ToList().Count * Obstaculo.NumFaltasXderriboObsExigente; 
                    
            int faltasXPasoObstaculoSimple =
                obstaculosPasadosConDerribo.Where( 
                    w => w.Obstaculo.TipoObstaculo == TipoObstaculo.simple).ToList().Count * Obstaculo.NumFaltasXderriboObsSimple; 

            resultadoParticipante.TotalFaltas = faltasXPasoObstaculoExigente + faltasXPasoObstaculoSimple;
            // si los competidores exceden el tiempo esperado de recorrido son sancionados. Por cada
            // segundo de exceso de tiempo se considera una falta
            if (pBinomio.TiempoEmpleado > this.TiempoEsperadoRecorrido)
            {
                int diferencia = pBinomio.TiempoEmpleado - this.TiempoEsperadoRecorrido;

                resultadoParticipante.TotalFaltas = resultadoParticipante.TotalFaltas + diferencia * 1;
            }

            // calculamos los puntos obtenidos por el binomio
            resultadoParticipante.TotalPuntos = 
                pBinomio.ObstaculosPasados.Where( w => w.Estado == EstadoObstaculoPasado.exito ).Sum( w => w.Obstaculo.Puntaje );

            return resultadoParticipante;
        }

        public void ElaborarRanking()
        {
            List<ResultadoParticipante> resultadoParticipantes = new List<ResultadoParticipante>();

            foreach (var regBinomio in this.participantes)
                resultadoParticipantes.Add(EvaluarParticipante(regBinomio));

            // Al final de la competencia se arma el ranking de cada categoría. Para generarlo se tiene en
            // cuenta el puntaje, a igual puntaje se considera el tiempo empleado, y a igual tiempo se
            // decide por menor cantidad de fallas.
            var clasificados = resultadoParticipantes.Where(
                w => w.Descalificado == false).OrderBy(w => w.TiempoEmpleado).ThenBy(w => w.TotalFaltas).ToList();

            Console.WriteLine("");
            Console.WriteLine("            ***  Ranking - Categoria " + this.Descripcion + "  ***");
            Console.WriteLine(" ___________________________________________________________________ ");
            Console.WriteLine("| Id Binomio      Total Puntos     Tiempo Empleado     Total Faltas |");
            Console.WriteLine("|___________________________________________________________________|");

            foreach (var resultadoBinomio in clasificados)
            {
                Console.WriteLine("       {0}            {1}                {2}                   {3}",
                    resultadoBinomio.Binomio.IdParticipante,
                    resultadoBinomio.TotalPuntos.ToString(), resultadoBinomio.TiempoEmpleado.ToString(),
                    resultadoBinomio.TotalFaltas.ToString());
            }

            Console.WriteLine("");
        }

        public void ImprimirRecorrido()
        {
            Console.WriteLine("Categoria: {0}", this.Descripcion);
            Console.WriteLine("--------------------------");

            Console.WriteLine("|************** OBSTACULOS **************|");
            Console.WriteLine("|----------------------------------------|");
            Console.WriteLine("| IDENTIFICACION    PUNTAJE              |");
            Console.WriteLine("|----------------------------------------|");


            foreach (var rec in this.recorrido.OrderBy(w => w.Orden))
            {
                rec.Obstaculo.Imprimir();
            }

            Console.WriteLine("|                                        |");
            Console.WriteLine("|________________________________________|");

        }
    }
}