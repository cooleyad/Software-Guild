using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLooringMastery.Objects;
using FLooringMastery.Models;

namespace FlooringMastery.Data
{
    public class OrderTestRepository : IOrderRepository
    {

        //create test account information here for workflows, ect like SGBank

        private static Order _order = new Order

        {
            OrderNumber = 1,
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M

        };

        public bool DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> LookupOrder(DateTime time)
        {
            throw new NotImplementedException();
        }

        public Order LookupOrder(DateTime time, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public bool SaveExistingOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool SaveNewOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
