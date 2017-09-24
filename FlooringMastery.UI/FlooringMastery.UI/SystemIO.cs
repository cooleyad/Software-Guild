using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlooringMastery.UI
{
    public class SystemIO
    {
        internal static string OrderDateRequest()
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("\nLookup Order Number");
            Console.WriteLine("\n==================================");
            Console.Write("\nPlease enter an order number: ");
            string userInput = Console.ReadLine();

            return userInput;
           
        }

        internal static void DisplayOrderDetails(object orders)
        {
            throw new NotImplementedException();
        }
    }
}
