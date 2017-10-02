using FlooringMastery.BLL;
using FlooringMastery.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class OrderEditWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();

            string userInput = SystemIO.OrderDateRequest();

            DateTime order = Convert.ToDateTime(userInput);

            int orderNumber = SystemIO.OrderNumberRequest();

            LookupOrderResponse response = manager.AccountByDateAndNumber(order, orderNumber);

            if (response.Success)
            {
                SystemIO.DisplaySingleOrderDetails(response.Order);
                Console.ReadKey();
                SystemIO.EditOrderMenu(response.Order);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("An error has occured: ");
            }
            Console.ReadKey();
        }
    }
}
