using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows.EditWorkflows
{
    public class EditAreaWorkflow
    {
        public void EditArea (Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            order.Area = SystemIO.EditGetArea();

            manager.SaveExistingOrder(order);
            SystemIO.DisplaySingleOrderDetails(order);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
