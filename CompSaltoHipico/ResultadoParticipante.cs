using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public class ResultadoParticipante
    {
        public Binomio Binomio { get; set; }
        public bool Descalificado { get; set; }
        public int TotalPuntos { get; set; }
        public int TotalFaltas  { get; set; }
        public int TiempoEmpleado { get; set; }

        public ResultadoParticipante()
        {
            this.Binomio = null;
            this.Descalificado = false;
            this.TotalPuntos = 0;
            this.TiempoEmpleado = 0;
            this.TotalFaltas = 0;
        }
    }
}