
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public class Experto : CategoriaSaltoHipico
    {
        public Experto(int pTiempoEsperado, EvaluarParticipante pEvaluarParticipante) : base(pTiempoEsperado, pEvaluarParticipante)
        {
            this.Descripcion = "EXPERTO"; // categoria
        }

    }
}