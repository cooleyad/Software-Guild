using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = false;

            do

            {
                SetUp flow = new SetUp();
                GameState state = flow.Start();

                Gameflow.PlayGame(state);
                break;
            }
            while (playAgain);
            {
                Console.WriteLine("Want to have another go at it?");
                Console.WriteLine("Press Y for yes, press N for no..");
                Console.WriteLine("Or just stare at the screen like a brain dead moron");
                Console.WriteLine("it's all good, you do you...");
                String userInput = Console.ReadLine();

                if (userInput== "Y" || userInput=="y")
                {
                    SetUp restart = new SetUp();
                    restart.Start();
                }
                else if (userInput== "N" || userInput== "n")
                {
                    return;
                }
            }

        }
    }
}
