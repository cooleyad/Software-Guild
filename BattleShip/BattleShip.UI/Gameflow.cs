using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.UI;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{

    //1. Create Boards
    //2. Player turn decision
    //3. take coordinates/shots until game is over


    public class Gameflow
    {
        internal static void PlayGame(GameState state)
        {
            Player AttackingPlayer = null;
            Player DefendingPlayer = null;


            bool Victorious = false;
            while (!Victorious)
            {

                if (state.IsPlayerOneTurn)
                {
                    AttackingPlayer = state.P1;
                    DefendingPlayer = state.P2;
                }
                else
                {
                    AttackingPlayer = state.P2;
                    DefendingPlayer = state.P1;
                }

                BshipOutput.DrawBoard(DefendingPlayer.PlayerBoard);

                {
                    var UserInput= BshipInput.GetCoordinate();


                    FireShotResponse response = DefendingPlayer.PlayerBoard.FireShot(UserInput);

                    //ShotHistory LastShot = new ShotHistory();

                    switch (response.ShotStatus)
                    {

                        case ShotStatus.Invalid:
                            Console.WriteLine("U WOT M8!? Not a valid coordinate. Try again bozo.");

                            break;

                        case ShotStatus.Hit:
                            Console.WriteLine("Hey look, you proved the haters wrong! You can hit something more than the broad side of a barn! Now it's the next players turn.");
                            Console.ReadLine();
                            state.IsPlayerOneTurn = !state.IsPlayerOneTurn;
                            Console.Clear();

                            break;

                        case ShotStatus.Miss:
                            Console.WriteLine("You missed, better luck next time.");
                            Console.ReadLine();
                            state.IsPlayerOneTurn = !state.IsPlayerOneTurn;
                            Console.Clear();


                            break;
                        case ShotStatus.Duplicate:
                            Console.WriteLine("U WOT M8!? Dont you know you already shot there?");

                            break;
                        case ShotStatus.Victory:
                            Console.WriteLine("Congratulations, you rained fire and fury down on your enemies, the likes of which they have never known...");
                            Console.ReadLine();
                            state.IsPlayerOneTurn = !state.IsPlayerOneTurn;
                            Console.Clear();


                            break;
                        case ShotStatus.HitAndSunk:
                            Console.WriteLine("To repeat the old phrase... You sunk their battleship! Well one of their ships anyway");


                            break;
                    }
                }
            }
        }
    }
}

