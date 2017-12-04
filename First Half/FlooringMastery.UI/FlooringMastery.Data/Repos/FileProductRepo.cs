using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Repos
{
    public class FileProductRepo : IProductRepository
    {
        public const string productPath = @"\\Mac\Home\Desktop\Sample Data\Products.txt";

        Dictionary<string, Product> _productDictionary;

        public FileProductRepo()
        {
            _productDictionary = LoadProduct().ToDictionary(d => d.ProductType);
        }

        public Product GetProductData(string productType)
        {
            if(_productDictionary.ContainsKey(productType))
            {
                return _productDictionary[productType];
            }
            else
            {
                return null;
            }
        }

        public List<Product> LoadProduct()
        {
            List<Product> productList = new List<Product>();

            using (StreamReader sr = new StreamReader(productPath))
            {
                sr.ReadLine();
                string line;

                while ((line=sr.ReadLine())!=null)
                {
                    Product product = new Product();
                    string[] columns = line.Split(',');

                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = decimal.Parse(columns[1]);
                    product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                    productList.Add(product);
                }
            }
            return productList;
        }
    }
}
