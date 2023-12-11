namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void Rover_Constructor()
        {
            uint x = 3;
            uint y = 5;
            char heading = 'S';

            Rover rover = new Rover(x, y, heading);

            // Assert
            Assert.AreEqual(x, rover.getXPosition());
            Assert.AreEqual(y, rover.getYPosition());
            Assert.AreEqual(heading, rover.getHeading());
        }

        [TestMethod]
        public void Rover_Move_Test()
        {
            // Beginning values
            uint xStart = 1;
            uint yStart = 2;
            Rover marsRoverN = new Rover(xStart, yStart, 'N');
            Rover marsRoverS = new Rover(xStart, yStart, 'S');
            Rover marsRoverE = new Rover(xStart, yStart, 'E');
            Rover marsRoverW = new Rover(xStart, yStart, 'W');

            // Update Orientation
            marsRoverN.navigateRover('M');
            marsRoverS.navigateRover('M');
            marsRoverE.navigateRover('M');
            marsRoverW.navigateRover('M');

            // Assert move worked correctly
            Assert.AreEqual(xStart, marsRoverN.getXPosition());
            Assert.AreEqual(yStart + 1, marsRoverN.getYPosition());

            Assert.AreEqual(xStart, marsRoverS.getXPosition());
            Assert.AreEqual(yStart - 1, marsRoverS.getYPosition());

            Assert.AreEqual(xStart + 1, marsRoverE.getXPosition());
            Assert.AreEqual(yStart, marsRoverE.getYPosition());

            Assert.AreEqual(xStart - 1, marsRoverW.getXPosition());
            Assert.AreEqual(yStart, marsRoverW.getYPosition());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_Rover_Command()
        {
            Rover rover = new Rover(5, 4, 'E');

            // Expected exception thrown here
            rover.navigateRover('P');
        }

        [TestMethod]
        public void Rover_Clockwise_Turn()
        {
            // Beginning values 
            uint xStart = 4;
            uint yStart = 2;
            char heading1 = 'S';
            char heading2 = 'E';
            Rover marsRover1 = new Rover(xStart, yStart, heading1);
            Rover marsRover2 = new Rover(xStart, yStart, heading2);

            // Update Orientation
            marsRover1.navigateRover('R');
            marsRover2.navigateRover('R');

            // Assert rover turn worked as expected
            Assert.AreEqual('W', marsRover1.getHeading());
            Assert.AreEqual('S', marsRover2.getHeading());
        }

        [TestMethod]
        public void Rover_CounterClockwise_Turn()
        {
            // Beginning values 
            uint xStart = 4;
            uint yStart = 2;
            char heading1 = 'S';
            char heading2 = 'N';
            Rover marsRover1 = new Rover(xStart, yStart, heading1);
            Rover marsRover2 = new Rover(xStart, yStart, heading2);

            // Update Orientation
            marsRover1.navigateRover('L');
            marsRover2.navigateRover('L');

            // Assert rover turn worked as expected
            Assert.AreEqual('E', marsRover1.getHeading());
            Assert.AreEqual('W', marsRover2.getHeading());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_RoverInput()
        {
            uint xStart = 3;
            uint yStart = 4;
            char badHeading = 'T';

            // Throw exception
            Rover badRover = new Rover(xStart, yStart, badHeading);
        }
    }
}