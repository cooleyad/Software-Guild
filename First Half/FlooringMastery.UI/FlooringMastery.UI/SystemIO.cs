using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringMastery.Models;
using FlooringMastery.UI.Workflows.EditWorkflows;

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

        internal static int OrderNumberRequest()
        {
            Console.WriteLine(BorderBar);
            Console.WriteLine("\nLookup Order Number");
            Console.WriteLine(BorderBar);
            Console.WriteLine("Please enter an order number: ");

            string orderNumber = Console.ReadLine();
            return int.Parse(orderNumber);
        }

        internal static void DisplaySingleOrderDetails(Order order)
        {
            Console.WriteLine(BorderBar);
            Console.WriteLine("Here is your order: ");
            Console.WriteLine(BorderBar);
            Console.WriteLine($"Order Number: {order.OrderNumber}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Tax Rate: {order.TaxData}");
            Console.WriteLine($"Product Type: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost Per Square Foot: {order.CostPerSquareFoot}");
            Console.WriteLine($"Labor Cost Per Square Foot: {order.LaborCostPerSquareFoot}");
            Console.WriteLine($"Material Cost: {order.MaterialCost}");
            Console.WriteLine($"Labor Cost: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
        }

        internal static void EditOrderMenu(Order order)
        {
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine(BorderBar);
                Console.WriteLine("Edit Menu: Please choose from the following menu what you wish to edit");
                Console.WriteLine(BorderBar);
                Console.WriteLine(BorderBar);
                Console.WriteLine("1. Customer Name");
                Console.WriteLine("2. State");
                Console.WriteLine("3. Product Type");
                Console.WriteLine("4. Area");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        isValid = true;
                        EditCustomerNameWorkflow editCustomerName = new EditCustomerNameWorkflow();
                        editCustomerName.EditCustomerName(order);
                        break;

                    case "2":
                        isValid = true;
                        EditStateWorkflow editState = new EditStateWorkflow();
                        editState.EditState(order);
                        break;
                    case "3":
                        isValid = true;
                        EditProductTypeWorkflow editProduct = new EditProductTypeWorkflow();
                        editProduct.EditProduct(order);
                        break;
                    case "4":
                        EditAreaWorkflow editArea = new EditAreaWorkflow();
                        editArea.EditArea(order);
                        break;
                    default:
                        break;
                }
            }
        }

        internal static string EditCustName()
        {
            Console.WriteLine(BorderBar);
            Console.WriteLine("Please enter your new customer name: ");
            Console.WriteLine(BorderBar);
            string editCustName = Console.ReadLine();
            return editCustName;
        }

        internal static string EditState()
        {
            Console.WriteLine(BorderBar);
            Console.WriteLine("Enter new State: ");
            Console.WriteLine(BorderBar);
            string userInput = Console.ReadLine();

            return userInput;
        }

        internal static string EditGetProduct()
        {
            Console.WriteLine(BorderBar);
            Console.WriteLine("Please enter the product ordered: ");
            string userInput = Console.ReadLine();
            Console.WriteLine(BorderBar);

            return userInput;
        }

        internal static decimal EditGetArea()
        {
            Console.WriteLine(BorderBar);
            Console.WriteLine("Enter the area for the order: ");
            Console.WriteLine(BorderBar);
            decimal userInput = decimal.Parse(Console.ReadLine());

            return userInput;
        }

        public static void DisplayOrderDetails(List <Order> orders)
        {
            Console.WriteLine("Here are your order details: ");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Number: {order.OrderNumber}");
                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.WriteLine($"State: {order.State}");
                Console.WriteLine($"Tax Rate: {order.TaxData}");
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
