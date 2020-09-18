using System;

namespace Zork
{
    class Program
    {
        private static int roomColumn;
        private static bool canMove;
        static void Main(string[] args)
        {
            roomColumn = 1;

            Console.WriteLine($"Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while(command != Commands.QUIT)
            {
                Console.Write($"{Rooms[roomColumn]}\n> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                        canMove = Move(command);
                        if (canMove == true)
                        {
                            roomColumn += 1;
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
                            roomColumn -= 1;
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

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static bool Move(Commands a)
        {
            switch (a)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                    return false;
                case Commands.EAST:
                    if (roomColumn + 1 >= Rooms.Length)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case Commands.WEST:
                    if(roomColumn - 1 <= -1)
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

        private static readonly string[] Rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
    }
}
