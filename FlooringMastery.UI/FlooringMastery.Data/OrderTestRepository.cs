using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class OrderTestRepository : IOrderRepository
    {

        //create test account information here for workflows, ect like SGBank

        private static readonly List<Order> _order = new List<Order>

        {
            new Order
            {
                Date=new DateTime(2018,1,1),
                OrderNumber = 1,
                CustomerName = "Wise",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
            },
            new Order
            {
                Date=new DateTime(2018,2,11),
                OrderNumber=2,
                CustomerName="Cooley",
                State="MI",
                TaxRate=5.75M,
                ProductType="Laminate",
                Area=200M,
                CostPerSquareFoot=1.75M,
                LaborCostPerSquareFoot=2.10M
            },


        };


        public bool DeleteOrder(Order order)
        {
            _order.Remove(order);
            return true;
        }

        public List<Order> LookupOrders(DateTime time)
        {
            List<Order> result = new List<Order>();
            foreach (var order in _order)
            {
                if (order.Date==time)
                {
                    result.Add(order);
                }
            }
            return result;
       
        }

        public Order LookupOrder(DateTime time, int orderNumber)
        {
            var dayOrders = LookupOrders(time);
            var orderChoice = dayOrders.SingleOrDefault(o => o.OrderNumber == orderNumber);
            return orderChoice;
        }

        public bool SaveExistingOrder(Order order)
        {
            _order.Add(order);
            return true;
        }

        public bool SaveNewOrder(Order order)
        {
            _order.Add(order);
            return true;
        }
    }
}
