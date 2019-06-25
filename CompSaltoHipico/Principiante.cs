
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public class Principiante : CategoriaSaltoHipico
    {
        public Principiante(int pTiempoEsperado) : base(pTiempoEsperado)
        {
            this.Descripcion = "PRINCIPIANTE"; // categoria
        }
    }
}