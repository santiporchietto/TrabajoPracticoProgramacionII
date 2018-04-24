using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpjuego
{
    public class Partida
    {
        private static List<Partida> partidas = new List<Partida>();

        private int Codigo { get; set; }

        public Jugador Jugador1 { get; set; }
        public Jugador Jugador2 { get; set; }
        public Mazo MazoPartida { get; set; }

        private Partida(int codigo, Jugador jugador1, Mazo mazo)
        {
            this.Codigo = codigo;
            this.Jugador1 = jugador1;
            this.MazoPartida = mazo;
        }

        public int RetornarCodigo()
        {
            return this.Codigo;
        }

        public static Partida CrearVerificarPartida(int codigo, Jugador jugador1, Mazo mazo)
        {
            var partida = partidas.SingleOrDefault(x => x.Codigo == codigo);

            if (partida == null)
            {
                partida = new Partida(codigo,jugador1,mazo);
                partidas.Add(partida);
            }
            return partida;
        }


        public void MezclarMazo()
        {
            Random NumeroRandom = new Random();
            for (int i = 0; i < MazoPartida.Cartas.Count(); i++)
            {
                int PosicionRandom = NumeroRandom.Next(0, MazoPartida.Cartas.Count());
                Carta AuxCarta = MazoPartida.Cartas[i];
                MazoPartida.Cartas[i] = MazoPartida.Cartas[PosicionRandom];
                MazoPartida.Cartas[PosicionRandom] = AuxCarta;
            }
        }

        public void RepartirCartas()
        {
            if (MazoPartida.Cartas != null && MazoPartida.Cartas.Count() != 0 && Jugador1 != null && Jugador2 != null)
            {
                this.MezclarMazo();
                int cantidadcartas = MazoPartida.Cartas.Count();
                if (cantidadcartas%2!=0)
                {
                    cantidadcartas -= 1;
                }
                for (int i = 0; i < cantidadcartas; i++)
                {
                    if (i%2==0)
                    {
                        Jugador1.RecibirCartas(MazoPartida.Cartas[i]);
                    }
                    else
                    {
                        Jugador2.RecibirCartas(MazoPartida.Cartas[i]);
                    }
                }
            }
        }

        private void CompararCartas (Carta cartajugador1, Carta cartajugador2, int atributo)
        {
            if (cartajugador1.Tipo==cartajugador2.Tipo)
            {
                if (cartajugador1.Atributos[atributo]==cartajugador2.Atributos[atributo])
                {

                }
            }
        }

    }
}
