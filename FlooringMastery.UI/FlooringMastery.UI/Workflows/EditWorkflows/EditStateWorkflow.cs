using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows.EditWorkflows
{
    public class EditStateWorkflow
    {
        public void EditState (Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            var newState = SystemIO.EditState();

            FindStateResponse response = manager.GetStateTax(newState);

            if(response.Success)
            {
                order.TaxRate = response.StateTax.TaxRate;

                manager.SaveExistingOrder(order);
                SystemIO.DisplaySingleOrderDetails(order);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                response.Success = false;
            }
        }
    }
}
