
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloCompetenciaSaltoHipico
{
    public class Binomio
    {
        public string IdParticipante { get; set;  }
        Jinete Jinete { get; set;  }
        Caballo Caballo { get; set;  }

        public List< ObstaculoPasado> ObstaculosPasados { get; }
        public int TiempoEmpleado { get; set; } // en segundos

        public Binomio(string pIdParticipante, Jinete pJinete, Caballo pCaballo)
        {
            this.IdParticipante = pIdParticipante;
            this.Jinete = pJinete;
            this.Caballo = pCaballo;

            this.ObstaculosPasados = new List<ObstaculoPasado>();
            this.TiempoEmpleado = 0;
        }

        public void AddObstaculoPasado( ObstaculoPasado pObstaculoPasado )
        {
            this.ObstaculosPasados.Add( pObstaculoPasado );
        }
    }
}