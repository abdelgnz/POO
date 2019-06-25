
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public class Recorrido
    {
        public Recorrido( CategoriaSaltoHipico pCategoriaSaltoHipico, Obstaculo  pObstaculo, int pOrden )
        {
			this.CategoriaSaltoHipico = pCategoriaSaltoHipico;
			this.Obstaculo = pObstaculo;
			this.Orden = pOrden;
        }

		public int Orden { get; set; }

		public Obstaculo Obstaculo { get; set; }
		public CategoriaSaltoHipico CategoriaSaltoHipico { get; set; }
    }
}