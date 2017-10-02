using FlooringMastery.BLL;
using FlooringMastery.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class OrderDeleteWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            string dateInput = SystemIO.OrderDateRequest();

            DateTime orderDate = Convert.ToDateTime(dateInput);

            int orderNumber = SystemIO.OrderNumberRequest();

            LookupOrderResponse response = manager.AccountByDateAndNumber(orderDate, orderNumber);

            if (response.Success)
            {
                manager.DeleteOrder(response.Order);
                Console.WriteLine("Order has been deleted.");
            }
            else
            {
                Console.WriteLine("An error has occured: ");
                Console.WriteLine(response.Message);
            }
            Console.ReadKey();
        }
    }
}
