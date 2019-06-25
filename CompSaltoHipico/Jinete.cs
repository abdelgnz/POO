
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModuloCompetenciaSaltoHipico
{
    public class Jinete : Persona
    {
        private string id;
        public Jinete(string pNombre, string pId) : base(pNombre)
        {
            this.id = pId;
        }

		public string Id { get => this.id; set => this.Id = value; }
    }
}