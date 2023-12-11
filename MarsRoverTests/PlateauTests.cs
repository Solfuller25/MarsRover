using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTests
{
    [TestClass]
    public class PlateauTests
    {
        [TestMethod]
        public void Plateau_GetDims_Returns_UInteger()
        {
            Plateau marsPlateau = new Plateau(5, 5);

            // Assert
            Assert.IsInstanceOfType(marsPlateau.getXBound(), typeof(uint));
            Assert.IsInstanceOfType(marsPlateau.getYBound(), typeof(uint));
        }

        [TestMethod]
        public void Plateau_Constructor()
        {
            uint x = 5;
            uint y = 4;

            Plateau plateau = new Plateau(x, y);

            // Assert
            Assert.AreEqual(x, plateau.getXBound());
            Assert.AreEqual(y, plateau.getYBound());
        }
    }
}
