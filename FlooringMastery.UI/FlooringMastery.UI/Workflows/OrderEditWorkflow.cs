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

            string dateInput = SystemIO.OrderDateRequest();

            DateTime orderDate = Convert.ToDateTime(dateInput);

            int orderNumberInput = SystemIO.OrderNumberRequest();

            LookupOrderResponse response = manager.AccountByDateAndNumber(orderDate, orderNumberInput);

            if (response.Success)
            {
                SystemIO.DisplaySingleOrderDetails(response.Order);
                Console.ReadKey();
                SystemIO.EditOrderMenu(response.Order);
            }
        }
    }
}
