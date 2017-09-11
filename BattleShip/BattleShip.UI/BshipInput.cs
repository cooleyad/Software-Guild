using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public static class BshipInput
    {
        internal static string GetNameFromPlayer(int PlayerNumber)
        {
            Console.WriteLine($"Player {PlayerNumber}, what is your name?");
            return Console.ReadLine();
        }

        internal static Coordinate GetCoordinate(string PlayerName)
        {
            bool IsValidCoordinate = false;

            Coordinate validCoordinate = null;
            while (!IsValidCoordinate)
            {
                Console.Write($"{PlayerName}, please enter a coordinate : ");


                String userInput = Console.ReadLine();
                IsValidCoordinate = CoordinateTryParse(userInput, out validCoordinate);
            }
            return validCoordinate;
        }


        public static bool CoordinateTryParse(string userInput, out Coordinate validCoordinate)
        {
            validCoordinate = null;
            if (userInput.Length > 1)
            {
                char yPart = userInput[0];
                String xPart = userInput.Substring(1);

                int ycol;
                int x;

                if (yPart >= 'a' && yPart <= 'j')
                {
                    if (int.TryParse(xPart, out x))
                    {
                        if (x >= 1 && x <= 10)
                        {
                            ycol = (yPart - 'a' + 1);
                            validCoordinate = new Coordinate(ycol, x);
                            return true;
                        }
                    }
                }
            }
            return false;
        }





        internal static ShipDirection GetDirection(string PlayerName, ShipType s)
        {

            Console.WriteLine($"{PlayerName}, please enter a direction for your ship {s}; use the directions u=up,d=down, L=left, and R=right: ");
            Console.WriteLine();

            string UserInput = Console.ReadLine();

            ShipDirection ship = new ShipDirection();

            switch (UserInput)
            {
                case "U":
                    ship = ShipDirection.Up;
                    break;
                case "D":
                    ship = ShipDirection.Down;
                    break;
                case "L":
                    ship = ShipDirection.Left;
                    break;
                case "R":
                    ship = ShipDirection.Right;
                    break;
                default:
                    ship = ShipDirection.Down;
                    break;
            }
            return ship;
        }
    }
}


