
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloCompetenciaSaltoHipico
{
    public class CampeonatoSaltoHipico
    {
		CategoriaSaltoHipico CategoriaPrincipiante { get;set; }
		CategoriaSaltoHipico CategoriaIntermedio { get;set; }
		CategoriaSaltoHipico CategoriaExperto { get;set; }

        public CampeonatoSaltoHipico(){
			this.CategoriaExperto = null;
			this.CategoriaIntermedio = null;
			this.CategoriaPrincipiante = null;
		}

    }

}