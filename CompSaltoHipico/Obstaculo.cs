
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloCompetenciaSaltoHipico
{
	public enum TipoObstaculo { simple, exigente, no_definido }
    public class Obstaculo
    {
		public string Id { get; set; }
		public int Puntaje { get; set; }
        public TipoObstaculo TipoObstaculo { get; set; } 
		public static int NumFaltasXderriboObsSimple = 1;
		public static int NumFaltasXderriboObsExigente = 3;

		public Obstaculo(string pId, int pPuntaje, TipoObstaculo pTipoObstaculo)
        {
			this.Id = pId;
			this.Puntaje = pPuntaje;
			this.TipoObstaculo = pTipoObstaculo;
        }
		
		public void Imprimir()
		{
			Console.WriteLine( "|       {0}           {1}                |", this.Id, this.Puntaje.ToString() );
		}
    }
}