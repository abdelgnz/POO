
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

        EvaluarParticipante _evaluarParticipante; // 

        public CategoriaSaltoHipico(int pTiempoEspRecorridoEnSegundos, EvaluarParticipante pEvaluarParticipante)
        {
            this.recorrido = new List<Recorrido>();
            this.TiempoEsperadoRecorrido = pTiempoEspRecorridoEnSegundos;
            this.participantes = new List<Binomio>();

            this._evaluarParticipante = pEvaluarParticipante;
        }

        public void SetEvaluarParticipante(EvaluarParticipante pEvaluarParticipante)
        {
            this._evaluarParticipante = pEvaluarParticipante;
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

        public void ElaborarRanking()
        {
            List<ResultadoParticipante> resultadoParticipantes = new List<ResultadoParticipante>();

            foreach (var regBinomio in this.participantes)
                resultadoParticipantes.Add( 
                    _evaluarParticipante.Evaluar( this.recorrido, this.TiempoEsperadoRecorrido,regBinomio ) );
                    

            // Al final de la competencia se arma el ranking de cada categoría. Para generarlo se tiene en
            // cuenta el puntaje, a igual puntaje se considera el tiempo empleado, y a igual tiempo se
            // decide por menor cantidad de fallas.
            var clasificados = resultadoParticipantes.Where(
                w => w.Descalificado == false).OrderBy( w=> w.TotalPuntos ).ThenBy(w => w.TiempoEmpleado).ThenBy(w => w.TotalFaltas).ToList();

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