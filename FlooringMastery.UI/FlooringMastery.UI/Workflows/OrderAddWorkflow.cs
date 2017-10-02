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
            OrderManager manager = OrderManagerFactory.Create();
            Order order = new Order();

            string dateInput = SystemIO.OrderDateRequest();
            DateTime orderDate = Convert.ToDateTime(dateInput);
            order.Date = orderDate;

            string input = SystemIO.EditCustName();
            order.CustomerName = input;

            string stateInput = SystemIO.EditState();
            OrderManager stateTax = OrderManagerFactory.Create();
            FindStateResponse stateResponse = manager.GetStateTax(stateInput);

            if (stateResponse.Success)
            {
                order.TaxRate = stateResponse.StateTax.TaxRate;
            }
            else
            {
                stateResponse.Success = false;
            }
            string productInput = SystemIO.EditGetProduct();
            OrderManager productManager = OrderManagerFactory.Create();
            FindProductTypeResponse findProduct = productManager.GetProductData(productInput);
            if (findProduct.Success)
            {
                order.ProductType = findProduct.Product.ProductType;
            }
            else
            {
                findProduct.Success = false;
            }

            decimal areaInput = SystemIO.EditGetArea();
            order.Area = areaInput;

            manager.SaveNewOrder(order);

            Console.ReadKey();

        }
    }
}
