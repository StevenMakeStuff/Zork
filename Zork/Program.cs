using System;

namespace Zork
{
    class Program
    {
        private static (int roomRow, int roomColumn) Location;
        private static bool canMove;
        static void Main(string[] args)
        {
            Location.roomColumn = 1;
            Location.roomRow = 1;

            Console.WriteLine($"Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while(command != Commands.QUIT)
            {
                Console.Write($"{Rooms[Location.roomRow, Location.roomColumn]}\n> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;
                                //Moves the character should an input return true.
                    case Commands.NORTH:
                        canMove = Move(command);
                        if (canMove == true)
                        {
                            Location.roomRow += 1;
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut!";
                        }
                        break;
                    case Commands.SOUTH:
                        canMove = Move(command);
                        if (canMove == true)
                        {
                            Location.roomRow -= 1;
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut!";
                        }
                        break;
                    case Commands.EAST:
                        canMove = Move(command);
                        if (canMove == true)
                        {
                            Location.roomColumn += 1;
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut!";
                        }
                        break;
                    case Commands.WEST:
                        canMove = Move(command);
                        if (canMove == true)
                        {
                            Location.roomColumn -= 1;
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut!";
                        }
                        break;

                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;

                    default:
                        outputString = "Unknown command.";
                        break;
                }

                Console.WriteLine(outputString);
            }
        }
                //Makes sure that the player is entering a valid string
        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static bool Move(Commands a)
        {       //checks to see if moving is possible
            switch (a)
            {
                case Commands.NORTH:
                    if (Location.roomRow + 1 > Rooms.GetUpperBound(0))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case Commands.SOUTH:
                    if (Location.roomRow - 1 <= -1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case Commands.EAST:
                    if (Location.roomColumn + 1 > Rooms.GetUpperBound(1))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case Commands.WEST:
                    if(Location.roomColumn - 1 <= -1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }

        private static readonly string[,] Rooms = {
            { "Rocky Trail", "South of House", "Canyon View" },
            { "Forest", "West of House", "Behind House" },
            { "Dense Woods", "North of House", "Clearing" },
        };
    }
}
