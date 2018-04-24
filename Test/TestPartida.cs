using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tpjuego;

namespace Test
{
    [TestClass]
    public class TestPartida
    {
        [TestMethod]
        public void DebePermitirMezclarMazo()
        {
            List<Carta> cartas = new List<Carta>();
            List<Atributo> atributos = new List<Atributo>();
            for (int i = 0; i < 10; i++)
            {
                Carta carta = new Carta(i+1, TipoDeCarta.Normal, atributos);
                cartas.Add(carta);
            }

            Mazo mazoOriginal = new Mazo(cartas);
            Mazo mazoCopia = new Mazo(cartas);

            Jugador jugador = new Jugador("1", "Pepe");

            Partida partida = Partida.CrearVerificarPartida(1, jugador, mazoCopia);
            partida.MezclarMazo();
            bool bandera = false;
            for (int i = 0; i < 10; i++)
            {
                if (partida.MazoPartida.Cartas[i].CodigoCarta!=mazoOriginal.Cartas[i].CodigoCarta)
                {
                    bandera = true;
                    break;
                }
            }
            Assert.AreEqual(true, bandera);

        }

    }
}
