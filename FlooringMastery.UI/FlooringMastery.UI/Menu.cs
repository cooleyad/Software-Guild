using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public static class Menu
    {
        public const string BorderBar = "\n==========================================";

        public static void Start()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine(BorderBar);
                Console.WriteLine("\nSWC Corp");
                Console.WriteLine(BorderBar);
                Console.WriteLine("\n1. Display an Order");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine(BorderBar);

                Console.WriteLine("\nQ to quit");
                Console.WriteLine(BorderBar);
                Console.WriteLine("\nEnterSelection: ");


                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        OrderLookupWorkflow lookupWorkflow = new OrderLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        OrderAddWorkflow orderAddWorkflow = new OrderAddWorkflow();
                        orderAddWorkflow.Execute();
                        break;
                    case "3":
                        OrderEditWorkflow orderEditWorkflow = new OrderEditWorkflow();
                        orderEditWorkflow.Execute();
                        break;
                    case "4":
                        throw new NotImplementedException();
                    case "Q":
                        return;
                }
            }
        }
    }
}
