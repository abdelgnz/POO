using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public class EvaluarParticipanteVersion1 : EvaluarParticipante
    {
        public ResultadoParticipante Evaluar( List<Recorrido> pColObstaculosCategoria, int pTiempoEsperadoRecorrido,
            Binomio pBinomio )
        {
            ResultadoParticipante resultadoParticipante = new ResultadoParticipante();
            resultadoParticipante.Binomio = pBinomio;
            resultadoParticipante.TiempoEmpleado = pBinomio.TiempoEmpleado;

            if (pBinomio.ObstaculosPasados.Count != pColObstaculosCategoria.Count)
                resultadoParticipante.Descalificado = true; // descalificado por no recorrer todo los OBS

            int k = 0;

            foreach (var rec in pColObstaculosCategoria.OrderBy(w => w.Orden))
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

            foreach (var regObsPasadoConDerribo in obstaculosPasadosConDerribo)
                resultadoParticipante.TotalFaltas += regObsPasadoConDerribo.Obstaculo.getFaltasXfalla();

            // si los competidores exceden el tiempo esperado de recorrido son sancionados. Por cada
            // segundo de exceso de tiempo se considera una falta
            if (pBinomio.TiempoEmpleado > pTiempoEsperadoRecorrido)
            {
                int diferencia = pBinomio.TiempoEmpleado - pTiempoEsperadoRecorrido;

                resultadoParticipante.TotalFaltas = resultadoParticipante.TotalFaltas + diferencia * 1;
            }

            // calculamos los puntos obtenidos por el binomio
            resultadoParticipante.TotalPuntos = 
                pBinomio.ObstaculosPasados.Where( w => w.Estado == EstadoObstaculoPasado.exito ).Sum( w => w.Obstaculo.Puntaje );

            return resultadoParticipante;
        }
    }
}


