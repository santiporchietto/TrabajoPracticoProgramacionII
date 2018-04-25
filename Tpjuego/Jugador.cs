using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpjuego
{
    public class Jugador
    {
        public string IdConnection { get; set; }
        public string Nombre { get; set; }
        public List<Carta> CartasAsignadas { get; set; }

        public Jugador(string id, string nombre)
        {
            this.IdConnection = id;
            this.Nombre = nombre;
            this.CartasAsignadas = new List<Carta>();
        }

        public void RecibirCartas(List<Carta> carta)
        {
            this.CartasAsignadas.AddRange(carta);
        }

        public void RecibirCartas(Carta carta)
        {
            this.CartasAsignadas.Add(carta);
        }

        public Carta JugarCarta()
        {
            Carta CartaJugada = this.CartasAsignadas[0];
            this.CartasAsignadas.Remove(this.CartasAsignadas[0]);
            return CartaJugada;
        }
    }
}
