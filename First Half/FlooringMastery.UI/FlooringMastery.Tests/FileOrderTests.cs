using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Data.Repos;
using FlooringMastery.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class FileOrderTests
    {
        private const string _directoryPath = @"\\Mac\Home\Desktop\Sample Data\";
        private const string _feederPath = @"\\Mac\Home\Desktop\Feeder";

        [SetUp]
        public void Setup()
        {
            DirectoryInfo testData = new DirectoryInfo(_directoryPath);
            DirectoryInfo feederData = new DirectoryInfo(_feederPath);

            foreach (var delete in testData.GetFiles())
            {
                delete.Delete();
            }

            foreach (var copy in feederData.GetFiles())
            {
                copy.CopyTo(Path.Combine(_directoryPath, copy.Name));
            }
        }

        [Test]
        public void ReadFromFileTest()
        {
            FileOrderRepo readingFile = new FileOrderRepo();

            Order order = new Order();

            string userInput = "06/01/2013";
            DateTime date = DateTime.Parse(userInput);
            int orderNumber = 1;

            List<Order> orders = readingFile.LookupOrders(date);

            Assert.AreEqual(1, orders.Count());

            for (int i = 0; i < orders.Count; i++)
            {
                if (orderNumber == orders[i].OrderNumber)
                {
                    List<Order> check = new List<Order>()
                    {
                        orders[i]
                    };
                    order = orders[i];
                    order.Date = date;
                }
            }
            Assert.AreEqual("06/01/2013", date.ToString("MM/dd/yyyy"));
            Assert.AreEqual(1, order.OrderNumber);
            Assert.AreEqual("Wise", order.CustomerName);
            Assert.AreEqual("OH", order.State);
            Assert.AreEqual(6.25, order.TaxData);
            Assert.AreEqual("Wood", order.ProductType);
            Assert.AreEqual(100, order.Area);
            Assert.AreEqual(5.15, order.CostPerSquareFoot);
            Assert.AreEqual(4.75, order.LaborCostPerSquareFoot);
            Assert.AreEqual(515, order.MaterialCost);
            Assert.AreEqual(475, order.LaborCost);
            Assert.AreEqual(61.875, order.Tax);
            Assert.AreEqual(1051.875, order.Total);
        }

        [Test]
        public void AddOrderTest()
        {
            Order orders = new Order();

            FileOrderRepo makeOrder = new FileOrderRepo();


            orders.Date = DateTime.Parse("01/01/2018");
            orders.OrderNumber = (1);
            orders.CustomerName = ("Cooley");
            orders.State = ("Michigan");
            orders.TaxData = (5.75M);
            orders.ProductType = ("Tile");
            orders.Area = (100);
            orders.CostPerSquareFoot = (3.5M);
            orders.LaborCostPerSquareFoot = (4.15M);

            makeOrder.SaveExistingOrder(orders);

            List<Order> list = makeOrder.LookupOrders(orders.Date);

            Assert.AreEqual(1, list.Count());

            Assert.AreEqual("01/01/2018", orders.Date.ToString("MM/dd/yyyy"));
            Assert.AreEqual(1, orders.OrderNumber);
            Assert.AreEqual("Cooley", orders.CustomerName);
            Assert.AreEqual("Michigan", orders.State);
            Assert.AreEqual(5.75, orders.TaxData);
            Assert.AreEqual("Tile", orders.ProductType);
            Assert.AreEqual(100, orders.Area);
            Assert.AreEqual(3.5, orders.CostPerSquareFoot);
            Assert.AreEqual(4.15, orders.LaborCostPerSquareFoot);
            Assert.AreEqual(350, orders.MaterialCost);
            Assert.AreEqual(415, orders.LaborCost);
            Assert.AreEqual(43.9875, orders.Tax);
            Assert.AreEqual(808.9875, orders.Total);
        }

        [Test]
        public void RemoveOrderTest()
        {

            FileOrderRepo removeFromMemory = new FileOrderRepo();

            string userInput = "06/01/2013";
            DateTime date = DateTime.Parse(userInput);
            int orderNumber = 1;

            List<Order> order = removeFromMemory.LookupOrders(date);

            Assert.AreEqual(1, order.Count());


            removeFromMemory.DeleteOrder(order[0]);

            List<Order> validate = removeFromMemory.LookupOrders(date);

            Assert.AreEqual(0, validate.Count());
        }
    }
}
