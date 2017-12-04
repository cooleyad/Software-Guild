using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows.EditWorkflows
{
    public class EditCustomerNameWorkflow
    {
        public void EditCustomerName (Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            order.CustomerName = SystemIO.EditCustName();

            manager.SaveExistingOrder(order);
            SystemIO.DisplaySingleOrderDetails(order);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
