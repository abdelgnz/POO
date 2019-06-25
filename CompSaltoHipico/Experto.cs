
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public class Experto : CategoriaSaltoHipico
    {
        public Experto(int pTiempoEsperado) : base(pTiempoEsperado)
        {
            this.Descripcion = "EXPERTO"; // categoria
        }

    }
}