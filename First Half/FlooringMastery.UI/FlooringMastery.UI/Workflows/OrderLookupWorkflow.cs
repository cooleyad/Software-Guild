using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class OrderLookupWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();

            string userInput = SystemIO.OrderDateRequest();

            DateTime order = Convert.ToDateTime(userInput);

            OrderResponse response = manager.LookupOrder(order);

            if (response.Success)
            {
                SystemIO.DisplayOrderDetails(response.Order);
            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
            }

            Console.ReadKey();
        }
    }
}
    