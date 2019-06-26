
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloCompetenciaSaltoHipico
{
    public class Intermedio : CategoriaSaltoHipico
    {
        public Intermedio(int pTiempoEsperado, EvaluarParticipante pEvaluarParticipante) : base(pTiempoEsperado, pEvaluarParticipante)
        {
            this.Descripcion = "INTERMEDIO"; // categoria
        }

    }
}