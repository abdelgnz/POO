
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloCompetenciaSaltoHipico
{
    public class Intermedio : CategoriaSaltoHipico
    {
        public Intermedio(int pTiempoEsperado) : base(pTiempoEsperado)
        {
            this.Descripcion = "INTERMEDIO"; // categoria
        }

    }
}