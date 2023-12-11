using System;
using System.ComponentModel.DataAnnotations;

namespace MarsRover
{
    // Object containing necessary info for a particularly curious-looking plateau
    public class Plateau
    {
        private uint xBound;
        private uint yBound;

        // Plateau Constructor
        // Initializes a new plateau with length and width
        public Plateau(uint x, uint y)
        {
            this.xBound = x;
            this.yBound = y;
        }

        // Returns the x dim of the plateau
        public uint getXBound()
        {
            return xBound;
        }

        // Returns the y dim of the plateau
        public uint getYBound()
        {
            return yBound;
        }
    }
}