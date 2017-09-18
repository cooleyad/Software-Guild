using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.ConsoleApplications
{
    public class userInput
    {
        public int getintfromuser(string prompt)
        {
            string input;
            int output; 

            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (int.TryParse(input, out output))
                    return output;

                Console.Write("That was not a valid interger... press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
