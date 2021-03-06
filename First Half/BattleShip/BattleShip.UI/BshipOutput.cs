﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.UI;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{

    //string name=GetPlayerName();
    //Board gameboard=BuildBoard();
    //Player P1=new Player (name , gameBoard);

    public static class BshipOutput
    {
        internal static void DisplayTitle()
        {
            Console.WriteLine("Welcome to Battleship! We swear this will be better than the movie...");
            Console.WriteLine();
            Console.WriteLine("Press any key to start the game.");
            Console.ReadKey();
            Console.Clear();
        }


        internal static void WelcomePlayers()
        {
            Console.WriteLine("You are the captain of the ship now...");
            Console.WriteLine();
        }

        internal static void TooFar()
        {
            Console.WriteLine("You have gone too far, please pick a new coordinate!");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void GGOverlap()
        {
            Console.WriteLine("Good grief, you aren't supposed to run your ships into each other!");
            Console.WriteLine();
            Console.WriteLine("Pick a new coordinate... A good one this time");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void PlaceSuccess()
        {
            Console.WriteLine("Congratulations! You managed to keep your fleet afloat! Now don't mess the next one up..");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void DrawBoard(Board PlayerBoard)
        {
            for (int y = 1; y < 11; y++)
            {
                for (int x = 1; x <= 11; x++)
                {
                    ShotHistory CurrentBoard = PlayerBoard.CheckCoordinate(new Coordinate(y, x));
                    switch (CurrentBoard)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("H");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("M");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case ShotHistory.Unknown:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("?");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                    }

                    Console.Write($"| ");
                }
                Console.WriteLine("");
                Console.WriteLine("--------------------------------");
                Board Drawboard = new Board();
            }
            Console.ReadLine();
        }

        internal static void GameOver()
        {
            Console.WriteLine("Contratulations, you won the game! Or did you...");
        }
    }
}
