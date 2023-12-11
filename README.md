Hello!

Thank you for reviewing my code. This is my solution to the Mars Rover problem presented by DealerOn as part of my application.

My solution involves three classes, a Rover, a Plateau, and a Program class for running the program. Starting with the Plateau object,
I used the uint variable to ensure the a Plateau could not be initialized with negative dimensions. My plateau contains an xBound
and a yBound property to define the dimensions of the plateau. I made these private to ensure they cannot be changed after defining
the Plateau object. Therefore I have two methods, one for retrieving each of the xBound and yBound values.

My Rover class also utilizes two uint variables to define the xPosition and yPosition of the Rover at any given time. I also have a 
char property to define the heading of the Rover at any given time. The constructor of my Rover object checks to make sure it is
receiving a valid heading value before constructing the Rover object. It will throw an ArgumentException if the heading is not one of
N, S, E, or W. My properties for the Rover object are also private to ensure the Rover's position and heading can only be updated using
the public navigateRover method. This method checks the given command and calls either the turnRover method to run the Rover in the 
specified direction, or the moveRover method to move the Rover forward one unit. My Rover class also contains a method inBounds which
returns a boolean value confirming whether or not the Rover is currently in the given xBound and yBound parameters.

My Program class loops through user input, checking for valid input via the console. If invalid input is provided, the user is prompted
to redo their input until their commands are successful. Certain exceptions will be thrown to help the user determine what part of 
their input needs reviewed. Finally, once the user's input is accepted, the program will output the final position for each given
Rover after completing their commands. If the Rover drove off of the given Plateau while following commands "Rover 'X' drove off the 
Plateau!" will be displayed for the corresponding Rover.


INSTRUCTIONS FOR INPUT BELOW:

This program always requires the user to input the plateau dimensions first, when prompted for input. The format for the plateau dims
are X[space]Y. An example of this is: "10 10". Only non-negative integers will be accepted. After inputting these values, the user must
press "ENTER" on their keyboard to create a newline and begin inputting rover details.

For the first line of Rover details, the user must input the X and Y coordinates of the beginning position of the Rover in identical
fashion to that of the plateau dimensions. Following the coordinates, the user must input the heading of the Rover as a capital letter.
Accepted coordinates are N, S, E, and W corresponding to each of the four cardinal directions North, South, East, and West. An example
of this input is: "9 9 S". The user must press "ENTER" on their keyboard after inputting the Rover position to begin inputting Rover commands.

The second line of the Rover details are the Rover commands. This value is one string of any three given characters (L, R, or M). The
L command will turn the Rover one turn to the Left. The R command will turn the Rover one turn to the Right. The M command will move
the Rover one position in the direction of it's current heading. An example of this valid input is: "RLMRMLRLRMLMMMRRL".

The user can input details for multiple Rovers, as long as they ensure the Rover Position and Rover Commands are consecutive for
any given Rover. Once the user has input the plateau dimensions and any number of Rover details, they must press "ENTER" on their keyboard
and type "run" in the console, followed by "ENTER" to execute the program. An example of a full, valid user input for two rovers is
shown below followed by an invalid input due to Rover starting position not being within provided plateau bounds:

VALID INPUT:
99 99
55 43 N
RLMLMRLRMLRMMRR
67 82 W
LMRMLRMRLMRMLR

INVALID INPUT:
20 20
32 25 W
RMLMRLMRLMRM