using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class ProductTestRepository : IProductRepository
    {
        private static readonly List<Product> Products = new List<Product>()
        {
            new Product
            {
                ProductType = "Wood",
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            },

            new Product
            {
                ProductType="Tile",
                CostPerSquareFoot=3.5M,
                LaborCostPerSquareFoot=4.15M
            },

            new Product
            {
                ProductType="Laminate",
                CostPerSquareFoot=1.75M,
                LaborCostPerSquareFoot=2.10M
            },

            new Product
            {
                ProductType="Carpet",
                CostPerSquareFoot=1.75M,
                LaborCostPerSquareFoot=2.10M
            }


        };

        public Product GetProductData(string productType)
        {
            return Products.SingleOrDefault(p => p.ProductType == productType);
        }

        public List<Product> LoadProduct()
        {
            return Products;
        }
    }
}
