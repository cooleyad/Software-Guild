using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringMastery.Models
{
    public class Order
    {
        public DateTime Date { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxData { get; set; }
        public string  ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost => Area * CostPerSquareFoot;
        public decimal LaborCost => Area * LaborCostPerSquareFoot;
        public decimal Tax => ((MaterialCost + LaborCost) * TaxData)/100;
        public decimal Total => (MaterialCost + LaborCost + Tax);

    }
}