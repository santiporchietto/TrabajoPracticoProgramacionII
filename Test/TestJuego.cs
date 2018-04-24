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
    public class TestJuego
    {
        [TestMethod]
        public void VerificarInstanciaUnica()
        {
            var juego1 = Juego.CrearVerificarJuego();
            var juego2 = Juego.CrearVerificarJuego();

            Assert.AreEqual(juego1, juego2);

        }
    }
}
