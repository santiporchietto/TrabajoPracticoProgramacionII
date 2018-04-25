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
            List<Carta> cartasMazoOriginal = new List<Carta>();
            List<Carta> cartasMazoCopia = new List<Carta>();
            List<Atributo> atributos = new List<Atributo>();
            for (int i = 0; i < 10; i++)
            {
                Carta carta = new Carta(i+1, TipoDeCarta.Normal, atributos);
                cartasMazoOriginal.Add(carta);
                cartasMazoCopia.Add(carta);
            }

            Mazo mazoOriginal = new Mazo(cartasMazoOriginal);
            Mazo mazoCopia = new Mazo(cartasMazoCopia);

            Jugador jugador = new Jugador("1", "Pepe");

            Partida partida = Partida.CrearVerificarPartida(1, jugador, mazoCopia);
            partida.MezclarMazo();
            bool flag = false;
            for (int i = 0; i < 10; i++)
            {
                if (partida.MazoPartida.Cartas[i].CodigoCarta!=mazoOriginal.Cartas[i].CodigoCarta)
                {
                    flag = true;
                    break;
                }
            }
            Assert.AreEqual(true, flag);

            partida.MezclarMazo();
            flag = false;
            for (int i = 0; i < 10; i++)
            {
                if (partida.MazoPartida.Cartas[i].CodigoCarta != mazoOriginal.Cartas[i].CodigoCarta)
                {
                    flag = true;
                    break;
                }
            }
            Assert.AreEqual(true, flag);

        }

        [TestMethod]
        public void DebePermitirRepartirMazo()
        {
            List<Carta> cartasMazo = new List<Carta>();
            List<Atributo> atributos = new List<Atributo>();



            //No debe permitir repartir cuando el mazo no tiene cartas y el jugador 2 es null
            Partida partidaIncompleta = Partida.CrearVerificarPartida(1, new Jugador("1", "Pepe"), new Mazo(cartasMazo));
            partidaIncompleta.RepartirCartas();
            Assert.AreEqual(null, partidaIncompleta.Jugador2);
            Assert.AreEqual(0, partidaIncompleta.Jugador1.CartasAsignadas.Count());

            //No debe permitir repartir cuando el mazo no tiene cartas
            partidaIncompleta.AgregarJugador(new Jugador("2", "Pablo"));
            partidaIncompleta.RepartirCartas();
            Assert.AreEqual(0, partidaIncompleta.Jugador1.CartasAsignadas.Count());
            Assert.AreEqual(0, partidaIncompleta.Jugador2.CartasAsignadas.Count());


            //Lleno mi lista de cartas
            for (int i = 0; i < 10; i++)
            {
                Carta carta = new Carta(i + 1, TipoDeCarta.Normal, atributos);
                cartasMazo.Add(carta);
            }

            //No debe permitir repartir cuando el jugador 2 es null
            Partida partida2 = Partida.CrearVerificarPartida(2, new Jugador("1","Pedro"), new Mazo(cartasMazo));
            partida2.RepartirCartas();
            Assert.AreEqual(0, partidaIncompleta.Jugador1.CartasAsignadas.Count());

            //Debe permitir repartir normalmente cuando hay datos
            partida2.AgregarJugador(new Jugador("2", "Juan"));
            partida2.RepartirCartas();

            Assert.AreEqual(cartasMazo.Count() / 2, partida2.Jugador1.CartasAsignadas.Count());
            Assert.AreEqual(cartasMazo.Count() / 2, partida2.Jugador2.CartasAsignadas.Count());

            bool flag = false;

            foreach (var cartas1 in partida2.Jugador1.CartasAsignadas)
            {
                flag = partida2.Jugador2.CartasAsignadas.Exists(x => x.CodigoCarta == cartas1.CodigoCarta);
                if (flag)
                {
                    break;
                }
            }

            Assert.AreEqual(false, flag);

            //No debe permitir repartir cuando el mazo es null y el jugador 2 es null
            Partida partida3 = Partida.CrearVerificarPartida(3, new Jugador("1", "Pepe"), null);
            partida3.RepartirCartas();
            Assert.AreEqual(null, partida3.Jugador2);
            Assert.AreEqual(null, partida3.MazoPartida);
            Assert.AreEqual(0, partidaIncompleta.Jugador1.CartasAsignadas.Count());
        }

    }
}
