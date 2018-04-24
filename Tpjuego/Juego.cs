using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpjuego
{
    public class Juego
    {
        public List<Partida> partidas { get; set; }

        private static Juego juegoUnico;

        private Juego()
        {
            partidas = new List<Partida>();
        }

        public static Juego CrearVerificarJuego()
        {
            if (juegoUnico == null)
            {
                juegoUnico = new Juego();
            }
            return juegoUnico;
        }
    }
}
