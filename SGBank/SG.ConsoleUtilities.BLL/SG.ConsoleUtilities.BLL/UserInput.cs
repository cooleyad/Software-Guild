using System;
using System.Collections.Generic;
using System.Text;

namespace SG.ConsoleUtilities.BLL
{
    public class UserInput
    {
        public static int GetIntFromUser(string prompt)
        {
            int result;
            string userInput;

            while (true)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                
                if (int.TryParse(userInput, out result))
                {
                    return result;
                }
                Console.WriteLine("This is not a valid input ");
            }
        }
    }
}
