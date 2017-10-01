using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    public class SystemIO
    {
        public const string BorderBar = "\n==========================================";

        public static string OrderDateRequest()
        {
            Console.WriteLine(BorderBar);
            Console.WriteLine("\nLookup Order Date");
            Console.WriteLine(BorderBar);
            Console.WriteLine("\nPlease enter an order date: ");
            string userInput = Console.ReadLine();

            return userInput;
           
        }

        internal static string EditCustName()
        {
            Console.WriteLine("Please enter your new customer name: ");
            string editCustName = Console.ReadLine();
            return editCustName;
        }

        internal static string EditState()
        {
            Console.WriteLine("Enter new State: ");
            string userInput = Console.ReadLine();

            return userInput;
        }

        //internal static int OrderNumberRequest()
        //{
        //    Console.WriteLine(BorderBar);
        //    Console.WriteLine("\nLookup Order Number");
        //    Console.WriteLine(BorderBar);
        //    Console.WriteLine("Please enter an order number: ");

        //    string orderNumber = Console.ReadLine();

        //    return int.Parse(orderNumber);
        //}

        public static void DisplayOrderDetails(List <Order> orders)
        {
            Console.WriteLine("Here are your order details: ");

            foreach (var order in orders)
            {
                Console.Clear();
                Console.WriteLine($"Order Number: {order.OrderNumber}");
                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.WriteLine($"State: {order.State}");
                Console.WriteLine($"Tax Rate: {order.TaxRate}");
                Console.WriteLine($"Product Type: {order.ProductType}");
                Console.WriteLine($"Area: {order.Area}");
                Console.WriteLine($"Cost Per Square Foot: {order.CostPerSquareFoot}");
                Console.WriteLine($"Labor Cost Per Square Foot: {order.LaborCostPerSquareFoot}");
                Console.WriteLine($"Material Cost: {order.MaterialCost}");
                Console.WriteLine($"Labor Cost: {order.LaborCost}");
                Console.WriteLine($"Tax: {order.Tax}");
                Console.WriteLine($"Total: {order.Total}");
            }
        }
    }
}
