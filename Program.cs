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
            Obstaculo obs1 = new ObstaculoSimple(pId: "OBS1", pPuntaje: 20);
            Obstaculo obs2 = new ObstaculoExigente(pId: "OBS2", pPuntaje: 30);
            Obstaculo obs3 = new ObstaculoSimple(pId: "OBS3", pPuntaje: 40);
            Obstaculo obs4 = new ObstaculoExigente(pId: "OBS4", pPuntaje: 50);
            Obstaculo obs5 = new ObstaculoExigente(pId: "OBS5", pPuntaje: 60);
            Obstaculo obs6 = new ObstaculoSimple(pId: "OBS6", pPuntaje: 70);
            Obstaculo obs7 = new ObstaculoExigente(pId: "OBS7", pPuntaje: 80);
            Obstaculo obs8 = new ObstaculoExigente(pId: "OBS8", pPuntaje: 90);

            // Jinete
            Jinete jineteManuel = new Jinete("MANUEL", "J1");
            Caballo caballoTormenta = new Caballo("TORMENTA");
            Binomio binomioB1 = new Binomio( "B1", jineteManuel, caballoTormenta);

            EvaluarParticipante evaluarParticipanteVersion1 = new EvaluarParticipanteVersion1();
            CategoriaSaltoHipico categoriaExperto = new Experto(  30, evaluarParticipanteVersion1);

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
           //26062019_1
        }
    }
}
