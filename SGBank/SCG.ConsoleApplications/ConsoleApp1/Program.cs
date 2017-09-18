using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCG.ConsoleApplications;

namespace VidApp
{
    class Program
    {
        static void Main(string[] args)
        {
            userInput ui= new userInput();

            int age = ui.getintfromuser("Enter your age: ");
            int numb = ui.getintfromuser("Enter your favorite number: ");

            Console.WriteLine($"Your age is {age} and your favorite number is {numb}");
            Console.ReadLine();
        }
    }
}
