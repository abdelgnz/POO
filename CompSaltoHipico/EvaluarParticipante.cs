using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public interface EvaluarParticipante
    {
        ResultadoParticipante Evaluar( List<Recorrido> pColObstaculosCategoria, int pTiempoEsperadoRecorrido,
            Binomio pBinomio );
    }
}


