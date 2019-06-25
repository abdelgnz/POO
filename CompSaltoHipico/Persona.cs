
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloCompetenciaSaltoHipico
{
    public class Persona
    {
        public String Nombre {get ; set; }
        
        public Persona(string pNombre) => this.Nombre = pNombre;
    }
}