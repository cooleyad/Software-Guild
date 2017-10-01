using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class OrderAddWorkflow
    {
        public void Execute()
        {
            TaxTestRepository manager = new;
            Order order = new Order();

            string dateInput = SystemIO.OrderDateRequest();
            DateTime orderDate = Convert.ToDateTime(dateInput);
            order.Date = orderDate;

            string input = SystemIO.EditCustName();
            order.CustomerName = input;

            string stateInput = SystemIO.EditState();
            //TaxTextRepository stateTax = OrderManagerFactory.Create();
            //FindStateResponse stateResponse =

        }
    }
}
