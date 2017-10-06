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

            string userInput = SystemIO.EditState();


            FindStateResponse stateResponse = manager.GetStateTax(userInput);
            order.State = userInput;
            if (stateResponse.Success)
            {
                order.TaxData = stateResponse.StateTax.TaxRate;
            }
            else
            {
                stateResponse.Success = false;
            }


            string productInput = SystemIO.EditGetProduct();
            OrderManager productManager = OrderManagerFactory.Create();
            FindProductTypeResponse findProduct = productManager.GetProductData(productInput);
            order.ProductType = productInput;
            if (findProduct.Success)
            {
                order.ProductType=findProduct.Product.ProductType;
                order.CostPerSquareFoot = findProduct.Product.CostPerSquareFoot;
                order.LaborCostPerSquareFoot = findProduct.Product.LaborCostPerSquareFoot;
            }
            else
            {
                findProduct.Success = false;
            }
            

            decimal areaInput = SystemIO.EditGetArea();
            order.Area = areaInput;

            manager.SaveNewOrder(order);

            SystemIO.DisplaySingleOrderDetails(order);


            Console.ReadKey();
        }
    }
}
