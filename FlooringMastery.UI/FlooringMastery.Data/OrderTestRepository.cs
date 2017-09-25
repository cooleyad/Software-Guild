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
    public class OrderTestRepository : IOrderFileRepository
    {

        private static OrderFile _order = new OrderFile

        {
            OrderNumber = 1,
            CustomerName="Wise",
            State="OH",
            TaxRate=6.25M,
            ProductType = "Wood",
            Area = 100M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M

        };

        //create test account information here for workflows, ect like SGBank


        public OrderFile LookupOrder(string OrderNumber)
        {
            throw new NotImplementedException();
        }
    }
}
