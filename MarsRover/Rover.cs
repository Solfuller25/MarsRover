using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MarsRover
{
    public class Rover
    {
        private uint xPosition;
        private uint yPosition;
        private char heading;

        // Rover Constructor
        // Initializes a new rover with position and heading
        public Rover(uint x, uint y, char roverHeading)
        {
            if (new List<char>(){ 'N', 'S', 'E', 'W'}.Contains(roverHeading))
            {
                this.xPosition = x;
                this.yPosition = y;
                this.heading = roverHeading;
            } else
            {
                throw new ArgumentException("message", nameof(roverHeading));
            }
        }

        // Returns the East-West (x) position of the rover
        public uint getXPosition()
        {
            return xPosition;
        }

        // Returns the North-South (y) position of the rover
        public uint getYPosition()
        {
            return yPosition;
        }

        // Returns the heading of the rover
        public char getHeading()
        {
            return heading;
        }

        // To String method to return string value of rover's position and heading
        public override string ToString()
        {
            return $"{this.xPosition} {this.yPosition} {this.heading}";
        }

        // Method to determine what type of movement method needs called for given command parameter
        public void navigateRover(char command)
        {
            // Won't do anything if command is empty
            if (command == 'M')
            {
                moveRover();
            } else if (command == 'L' || command == 'R')
            {
                turnRover(command);
            } else
            {
                throw new ArgumentException("Invalid command given to rover. Please try again");
            }
        }

        // Method to move the rover one position in the direction of it's heading
        private void moveRover()
        {
            // Get the char representation of the heading of the rover
            var heading = this.heading;

            // Switch statement to determine movement for each of the 4 directions
            switch (heading)
            {
                case 'N':
                    // Add 1 to Y direction
                    this.yPosition++;
                    break;
                case 'S':
                    // Subtract 1 from Y direction
                    this.yPosition--;
                    break;
                case 'E':
                    // Add 1 to X direction
                    this.xPosition++;
                    break;
                case 'W':
                    // Subtract 1 from X direction
                    this.xPosition--;
                    break;
            }
        }

        // Method to turn the positioning of the rover in the specified direction
        private void turnRover(char turnDirection)
        {
            if (turnDirection == 'L')
            {
                // Turn rover heading one position counter-clockwise
                switch (heading)
                {
                    case 'N':
                        heading = 'W';
                        break;
                    case 'W':
                        heading = 'S';
                        break;
                    case 'S':
                        heading = 'E';
                        break;
                    case 'E':
                        heading = 'N';
                        break;
                }
            }
            else
            {
                // Turn rover heading one position clockwise
                switch (heading)
                {
                    case 'N':
                        heading = 'E';
                        break;
                    case 'E':
                        heading = 'S';
                        break;
                    case 'S':
                        heading = 'W';
                        break;
                    case 'W':
                        heading = 'N';
                        break;
                }
            }
        }

        // Method to check if this rover's current position is in bounds
        // Input x and y boundaries of currnet plateau
        // Returns true if in bounds, else returns false
        public bool inBounds(uint xBound, uint yBound)
        {
            return (this.xPosition <= xBound && this.yPosition <= yBound
                && this.xPosition >= 0 && this.yPosition >= 0);
        }
    }
}
