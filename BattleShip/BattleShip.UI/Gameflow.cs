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

namespace BattleShip.UI
{

    //1. Create Boards
    //2. Player turn decision
    //3. take coordinates/shots until game is over


    public class Gameflow
    {
        internal ShotStatus PlayGame(GameState state)
        {
            {
                Player AttackingPlayer = null;
                Player DefendingPlayer = null;

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

                BshipOutput.DrawBoard();

                {
                    BshipInput.PromptShotCoord();
                    string UserInput = Console.ReadLine();

                    ShotStatus LastShot = new ShotStatus();

                    if (LastShot !=ShotStatus.Victory)

                    switch(LastShot)
                    {
                            case ShotStatus.Invalid:
                                Console.Write($"you have entered an invalid coordinate, what are you thinking? Try again bozo!");

                            break;

                        case ShotStatus.Duplicate :
                            Console.WriteLine($"Really!? You have entered a duplicate coordinate. Just.. Try again.");
                            
                            
                            break;

                        case ShotStatus.Miss :
                            Console.WriteLine($"Well, you missed. Better luck next time.");

                            break;

                        case ShotStatus.Hit:
                            Console.WriteLine($"Hey look, you managed to hit something! Keep it up bucko!");

                            break;

                        case ShotStatus.HitAndSunk:
                            Console.WriteLine($" You sunk their ship! Look at you.");

                            break;

                        case ShotStatus.Victory:
                            Console.WriteLine($"You won! Your enemies have experienced fire and fury like they have never known and never will know again...");
                            Console.WriteLine("Because, well, you know, they sank with their ships");

                            break;
                    }
                    return LastShot;                   
                }
            }
        }
    }
}

