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
    static class BshipInput
    {
        internal static string GetNameFromPlayer(int PlayerNumber)
        {
            Console.WriteLine($"Player {PlayerNumber}, what is your name?");
            return Console.ReadLine();
        }

        internal static Coordinate GetCoordinate()
        {
            int ycol;
            int x = -1;
            char yPart = 'a';
            bool IsValidCoordinate = false;
            {
                while (!IsValidCoordinate)
                {
                    Console.Write("Please enter a coordinate for ship : ");
                    Console.WriteLine();

                    string UserInput = Console.ReadLine();

                     yPart = UserInput[0];

                    string xPart = UserInput.Substring(1);

                    if (yPart >= 'a' && yPart <= 'j')
                    {
                        if (int.TryParse(xPart, out x))
                        {
                            if (x >= 1 && x <= 10)
                            {
                                IsValidCoordinate = true;
                            }
                        }
                    }
                }
                 ycol = (yPart - 'a' + 1);
                    Coordinate GoodCoord = new Coordinate(ycol, x);
                return GoodCoord;

            }


        }

        internal static Coordinate PromptShotCoord()
        {
            int ycol;
            int x = -1;
            char yPart = 'a';
            bool IsValidCoordinate = false;
            {
                while (IsValidCoordinate)
                {
                    Console.Write("please enter a coordinate to reign fire and fury down upon, the likes of which we have never seen before: ");
                    Console.WriteLine();
                    Console.ReadLine();

                    string UserInput = Console.ReadLine();

                    yPart = UserInput[0];

                    string xPart = UserInput.Substring(1);

                    if (yPart >= 'a' && yPart <= 'j')
                    {
                        if (int.TryParse(xPart, out x))
                        {
                            if (x >= 1 && x <= 10)
                            {
                                IsValidCoordinate = true;
                            }
                        }
                    }
                }
                ycol = (yPart - 'a' + 1);
                Coordinate GoodCoord = new Coordinate(ycol, x);
                return GoodCoord;
            }
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
