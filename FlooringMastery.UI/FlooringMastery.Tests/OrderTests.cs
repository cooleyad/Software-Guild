using FlooringMastery.BLL;
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
    public class OrderTests
    {
        private const string _directoryPath = @"\\Mac\Home\Desktop\Sample Data\";
        private const string _feederPath = @"\\Mac\Home\Desktop\Feeder";

        [SetUp]
        public void Setup()
        {
            DirectoryInfo testData = new DirectoryInfo(_directoryPath);
            DirectoryInfo feederData = new DirectoryInfo(_feederPath);
            foreach(var delete in testData.GetFiles())
            {
                delete.Delete();
            }

            foreach(var copy in feederData.GetFiles())
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

            for (int i=0; i<orders.Count; i++)
            {
                if (orderNumber==orders[i].OrderNumber)
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
            FileOrderRepo makeOrder = new FileOrderRepo();

            Order orders = new Order();

            OrderManager manager = OrderManagerFactory.Create();

            orders.Date = DateTime.Parse("06/01/2013");
            orders.OrderNumber = (2);
            orders.CustomerName = ("Wise");
            orders.State = ("OH");
            orders.TaxData = (6.25M);
            orders.ProductType = ("Wood");
            orders.Area = (100);
            orders.CostPerSquareFoot = (5.15M);
            orders.LaborCostPerSquareFoot = (4.75M);

            manager.SaveNewOrder(orders);
            makeOrder.SaveExistingOrder(orders);

            List<Order> list = makeOrder.LookupOrders(orders.Date);

            Assert.AreEqual(2, list.Count());

            Assert.AreEqual("06/01/2013", orders.Date.ToString("MM/dd/yyyy"));
            Assert.AreEqual(2, orders.OrderNumber);
            Assert.AreEqual("Wise", orders.CustomerName);
            Assert.AreEqual("OH", orders.State);
            Assert.AreEqual(6.25, orders.TaxData);
            Assert.AreEqual("Wood", orders.ProductType);
            Assert.AreEqual(100, orders.Area);
            Assert.AreEqual(5.15, orders.CostPerSquareFoot);
            Assert.AreEqual(4.75, orders.LaborCostPerSquareFoot);
            Assert.AreEqual(515, orders.MaterialCost);
            Assert.AreEqual(475, orders.LaborCost);
            Assert.AreEqual(61.875, orders.Tax);
            Assert.AreEqual(1051.875, orders.Total);
        }

        [Test]
        public void RemoveOrderTest()
        {
            FileOrderRepo removeFromMemory = new FileOrderRepo();

            Order orders = new Order();

            OrderManager manager = OrderManagerFactory.Create();

            string userInput = "06/01/2013";
            DateTime date = DateTime.Parse(userInput);
            int orderNumber = 1;

            List<Order> order = removeFromMemory.LookupOrders(date);

            Assert.AreEqual(1, order.Count());

            for (int i=0; i<order.Count; i++)
            {
                if (orderNumber==order[i].OrderNumber)
                {
                    List<Order> check = new List<Order>()
                    {
                        order[i]
                    };
                    orders = order[i];
                    orders.Date = date;
                }
            }
            manager.DeleteOrder(orders);
            removeFromMemory.DeleteOrder(orders);

            List<Order> validate = removeFromMemory.LookupOrders(date);

            Assert.AreEqual(0, validate.Count());
        }
    }
}
