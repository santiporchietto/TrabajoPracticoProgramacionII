using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpjuego
{
    public enum TipoDeCarta { Normal, Roja, Amarilla, Negra}

    public class Carta
    {
        //Prueba commit Said
        public int CodigoCarta { get; set; }
        public TipoDeCarta Tipo { get; set; }
        public List<Atributo> Atributos { get; set; }

        public Carta(int codigo, TipoDeCarta tipo, List<Atributo>atributos)
        {
            this.CodigoCarta = codigo;
            this.Tipo = tipo;
            this.Atributos = atributos;
        }
    }
}
