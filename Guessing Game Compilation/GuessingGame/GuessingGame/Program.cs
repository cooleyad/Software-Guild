using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess;
            string playerInput;
            string name=Console.ReadLine();

            Random r = new Random();
            theAnswer = r.Next(1, 21);

            Console.WriteLine("Enter your name here: ");
            Console.ReadLine();
                        
            do
            {
                // get player input
                Console.Write($"{name} Enter your guess (1-20): ");
                playerInput = Console.ReadLine();

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    if (playerGuess == theAnswer)
                    {
                        Console.WriteLine($"{name}, {theAnswer} was the number.  You Win!");
                        break;
                    }
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            Console.WriteLine($" {name}, Your guess was too High!");
                        }
                        else
                        {
                            Console.WriteLine($"{name}, Your guess was too low!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{name}, That wasn't a number!");
                }

            } while (true);

            Console.WriteLine($"{name}, Press any key to quit.");
            Console.ReadKey();
        }
    }
}
