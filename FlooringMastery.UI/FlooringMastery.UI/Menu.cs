using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("\nSWC Corp");
                Console.WriteLine("\n==================================");
                Console.WriteLine("\n1. Display an Order");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("\n==================================");

                Console.WriteLine("\nQ to quit");
                Console.WriteLine("\n==================================");
                Console.WriteLine("\nEnterSelection: ");


                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        new NotImplementedException();
                        break;
                    case "2":
                        new NotImplementedException();
                        break;
                    case "3":
                        new NotImplementedException();
                        break;
                    case "4":
                        new NotImplementedException();
                        break;
                    case "Q":
                        return;
                }
            }
        }
    }
}
