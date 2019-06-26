
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloCompetenciaSaltoHipico
{
    public abstract class Obstaculo
    {
		public string Id { get; set; }
		public int Puntaje { get; set; }

		public Obstaculo(string pId, int pPuntaje)
        {
			this.Id = pId;
			this.Puntaje = pPuntaje;
        }
		
		public abstract int getFaltasXfalla();
		public void Imprimir()
		{
			Console.WriteLine( "|       {0}           {1}                |", this.Id, this.Puntaje.ToString() );
		}
    }
}