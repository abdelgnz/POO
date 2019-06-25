using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ModuloCompetenciaSaltoHipico;

namespace ProyectoCompSaltoHipico
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obstaculos
            Obstaculo obs1 = new Obstaculo(pId: "OBS1", pPuntaje: 20, pTipoObstaculo: TipoObstaculo.simple);
            Obstaculo obs2 = new Obstaculo(pId: "OBS2", pPuntaje: 30, pTipoObstaculo: TipoObstaculo.exigente);
            Obstaculo obs3 = new Obstaculo(pId: "OBS3", pPuntaje: 40, pTipoObstaculo: TipoObstaculo.simple);
            Obstaculo obs4 = new Obstaculo(pId: "OBS4", pPuntaje: 50, pTipoObstaculo: TipoObstaculo.exigente);
            Obstaculo obs5 = new Obstaculo(pId: "OBS5", pPuntaje: 60, pTipoObstaculo: TipoObstaculo.exigente);
            Obstaculo obs6 = new Obstaculo(pId: "OBS6", pPuntaje: 70, pTipoObstaculo: TipoObstaculo.simple);
            Obstaculo obs7 = new Obstaculo(pId: "OBS7", pPuntaje: 80, pTipoObstaculo: TipoObstaculo.exigente);
            Obstaculo obs8 = new Obstaculo(pId: "OBS8", pPuntaje: 90, pTipoObstaculo: TipoObstaculo.exigente);

            // Jinete
            Jinete jineteManuel = new Jinete("MANUEL", "J1");
            Caballo caballoTormenta = new Caballo("TORMENTA");
            Binomio binomioB1 = new Binomio( "B1", jineteManuel, caballoTormenta);

            CategoriaSaltoHipico categoriaExperto = new Experto( pTiempoEsperado: 30);

            categoriaExperto.AddObstaculo( obs1, pOrden: 1 );
            categoriaExperto.AddObstaculo( obs5, pOrden: 2 );
            categoriaExperto.AddObstaculo( obs6, pOrden: 3 );
            categoriaExperto.AddObstaculo( obs8, pOrden: 4 );
            categoriaExperto.AddObstaculo( obs3, pOrden: 5 );
            categoriaExperto.AddObstaculo( obs2, pOrden: 6 );

            categoriaExperto.AddParticipante(binomioB1);

            var colObstaculosPasadosBinomioB1 = new Dictionary<string, EstadoObstaculoPasado>()
             {
                { "OBS1", EstadoObstaculoPasado.exito },
                { "OBS5", EstadoObstaculoPasado.derribo },
                { "OBS6", EstadoObstaculoPasado.exito },
                { "OBS8", EstadoObstaculoPasado.exito },
                { "OBS3", EstadoObstaculoPasado.derribo },
                { "OBS2", EstadoObstaculoPasado.exito }
            };

            categoriaExperto.RegistrarParticipacion(  binomioB1,   29,  colObstaculosPasadosBinomioB1);

            categoriaExperto.ElaborarRanking();
           
        }
    }
}
