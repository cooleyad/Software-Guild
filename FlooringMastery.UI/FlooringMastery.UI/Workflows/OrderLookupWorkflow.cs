using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
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
            OrderFileManager manager = OrderManagerFactory.Create();

            Console.Clear();

            string userInput = SystemIO.OrderDateRequest();

            DateTime order = Convert.ToDateTime(userInput);
        }
    }
}
