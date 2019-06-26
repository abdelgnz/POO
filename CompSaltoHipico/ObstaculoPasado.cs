using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public enum EstadoObstaculoPasado { exito, derribo, no_definido }
    public class ObstaculoPasado
    {
        public Obstaculo Obstaculo { get; set; }

        ///<summary>
        /// Valores que puede tomar  => exito | derribo
        ///</summary>
        public EstadoObstaculoPasado Estado { get; set; } // exito | derribo

        public ObstaculoPasado(Obstaculo pObstaculo, EstadoObstaculoPasado pEstado)
        {
            this.Obstaculo = pObstaculo;
            this.Estado = pEstado;
        }
    }
}