using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter input below using format specified in program instructions:");

            // List of lines inputted by user
            List<string> input = new List<string>();

            // Boolean value set to true when we confirm input is valid
            bool invalidInput = false;
            string outputToPrint = "";
            do
            {
                input.Clear();

                // loop through user input until "run" command is given
                while (true)
                {
                    string? line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    if (line.ToUpper() == "RUN")
                    {
                        break;
                    }
                    input.Add(line);
                }

                // Call helper method to execute user's commands
                outputToPrint = executeCommands(input);

                // Check for error in parsing input                
                if (outputToPrint == "ERROR")
                    invalidInput = true;
                else
                    break;
            } while (invalidInput);
            
            // Output the result of landing on mars
            Console.WriteLine(outputToPrint);
        }

        // This method implements the rover and plateau and runs each rovers commands.
        // Returns the string of details for each rover after completion
        public static string executeCommands(List<string> userInput)
        {
            string toReturn = "";

            try
            {
                // Get first line of user input (plateau dims)
                List<string> plateauDims = userInput[0].Split(" ").ToList();

                // Confirm plateau dims are valid and build plateau
                if (!validPlateauInput(plateauDims))
                {
                    throw new ArgumentException("Please provide 2 non-negative integer values for the plateau dims.");
                }
                Plateau marsPlateau = new Plateau(UInt32.Parse(plateauDims[0]), UInt32.Parse(plateauDims[1]));

                // Loop through user input, two lines at a time
                for (int i = 1; i < userInput.Count; i += 2)
                {
                    // First of two lines contains position and heading for rover
                    List<string> roverDetails = userInput[i].Split(" ").ToList();

                    // If valid rover input, build rover
                    if (!validRoverInput(roverDetails, marsPlateau))
                    {
                        throw new ArgumentException("Please provide rover position as two positive integers, within the plateau bounds.");
                    }
                    Rover marsRover = new Rover(UInt32.Parse(roverDetails[0]), UInt32.Parse(roverDetails[1]), Char.Parse(roverDetails[2]));

                    // Second of two lines contains commands to move the rover
                    List<char> roverCommands = userInput[i + 1].ToCharArray().ToList();
                    // For each rover command, check to confirm rover is still within plateau bounds
                    foreach (char command in roverCommands)
                    {
                        marsRover.navigateRover(command);
                        if (marsRover.inBounds(marsPlateau.getXBound(), marsPlateau.getYBound())) continue; else break;
                    }

                    // If rover is within bounds, return its position. Else print error
                    if (marsRover.inBounds(marsPlateau.getXBound(), marsPlateau.getYBound()))
                    {
                        toReturn += $"\nRover {(i + 1) / 2}'s final position:\n" + marsRover.ToString() + "\n";
                    }
                    else
                    {
                        toReturn += $"\nRover {(i + 1) / 2} drove off the plateau!\n";
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid User Input. Please review input requirements and try again.");
                toReturn = "ERROR";
            }

            return toReturn;
        }

        // Method used to check the plateau dimensions are valid
        // Returns true if dims are valid, false otherwise
        public static bool validPlateauInput(List<string> input)
        {
            if (input.Count >= 2)
            {
                return UInt32.TryParse(input[0], out uint plateauX)
                    && UInt32.TryParse(input[1], out uint plateauY);
            } else
            {
                return false;
            }
        }

        // Method used to check the rover starting position is valid
        // Returns true if starting position is valid, false otherwise
        public static bool validRoverInput(List<string> input, Plateau plateau)
        {
            if (input.Count >= 3)
            {
                return UInt32.TryParse(input[0], out uint roverX) && roverX <= plateau.getXBound()
                    && UInt32.TryParse(input[1], out uint roverY) && roverY <= plateau.getYBound();
            } else
            {
                return false;
            }
        }
    }
}
