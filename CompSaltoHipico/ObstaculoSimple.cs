using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloCompetenciaSaltoHipico
{
    public class ObstaculoSimple : Obstaculo
    {
        public ObstaculoSimple(string pId, int pPuntaje) : base(pId, pPuntaje)
        {
        }

        public override int getFaltasXfalla()
        {
            return 1;
        }
    }
}