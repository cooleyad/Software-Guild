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
    public class EditProductTypeWorkflow
    {
        public void EditProduct(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            var newProduct = SystemIO.EditGetProduct();

            FindProductTypeResponse response = manager.GetProductData(newProduct);

            if (response.Success)
            {
                order.ProductType = response.Product.ProductType;

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
