using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data.Repos
{
    public class FileOrderRepo : IOrderRepository
    {
        public const string DirectoryPath = @"\\Mac\Home\Desktop\Sample Data\Orders_06012013.txt";

        FileTaxRepo _fileTaxRepo = new FileTaxRepo();

        FileProductRepo _fileProductRepo = new FileProductRepo();

        public FileOrderRepo(FileTaxRepo taxRepo, FileProductRepo productRepo)
        {
            _fileTaxRepo = taxRepo;
            _fileProductRepo = productRepo;
        }

        public bool DeleteOrder(Order order)
        {
            List<Order> orderList = LookupOrders(order.Date);

            orderList.Remove(order);

            string header = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot," +
                "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";

            string orderString = "Orders_";

            string userInput = DirectoryPath + orderString + String.Format(order.Date.ToString("MMddyyyy")) + ".txt";

            using (StreamWriter sw = new StreamWriter(userInput))
            {
                sw.WriteLine(header);

                foreach(var singleOrder in orderList)
                {
                    if (singleOrder.OrderNumber==order.OrderNumber)
                    {

                    }
                    else
                    {
                        string row = $"{singleOrder.OrderNumber}, {singleOrder.CustomerName}, {singleOrder.State}, " +
                            $"{singleOrder.TaxRate}, {singleOrder.ProductType}, {singleOrder.Area}, {singleOrder.CostPerSquareFoot}, " +
                            $"{singleOrder.LaborCostPerSquareFoot}, {singleOrder.MaterialCost}, {singleOrder.LaborCost}, " +
                            $"{singleOrder.Tax},{singleOrder.Total}";

                        sw.WriteLine(row);
                    }
                }

            }
            return true;
        }

        public Order LookupOrder(DateTime time, int orderNumber)
        {
            var dailyOrders=LookupOrders(time);

            var selectedOrder = dailyOrders.SingleOrDefault(s => s.OrderNumber == orderNumber);

            return selectedOrder;
        }

        public List<Order> LookupOrders(DateTime time)
        {
            List<Order> orderList = new List<Order>();

            string orderString = "Orders_";

            string userInput = DirectoryPath + orderString + string.Format(time.ToString("MMddyyyy")) + ".txt";

            if (File.Exists(userInput))
                {
                using (StreamReader sr = new StreamReader(userInput))
                {
                    sr.ReadLine();
                    string line;

                    while((line=sr.ReadLine())!= null)
                    {
                        Order order = new Order();

                        string[] columns = line.Split(',');

                        order.OrderNumber = int.Parse(columns[0]);
                        order.CustomerName = columns[1];
                        _fileTaxRepo.State(columns[2]);
                        _fileProductRepo.GetProductData(columns[4]);
                        decimal.Parse(columns[5]);

                        order.Date = time;

                        orderList.Add(order);
                    }
                }
            }
            return orderList;
        }

        public bool SaveExistingOrder(Order order)
        {
            List<Order> orderList = LookupOrders(order.Date);

            orderList.Remove(order);

            string header = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";

            string orderString = "Orders_";

            string userInput = DirectoryPath + orderString + String.Format(order.Date.ToString("MMddyyyy")) + ".txt";

            using (StreamWriter sw = new StreamWriter(userInput))
            {
                sw.WriteLine(header);

                foreach (var anOrder in orderList)
                {
                    Order saveOrder = anOrder;
                    {
                        if (anOrder.OrderNumber==order.OrderNumber)
                        {
                            saveOrder = order;
                        }
                        else
                        {
                            string row = $"{saveOrder.OrderNumber}, {saveOrder.CustomerName}, {saveOrder.State}, {saveOrder.TaxRate}, {saveOrder.ProductType}, {saveOrder.Area}, {saveOrder.CostPerSquareFoot}, {saveOrder.LaborCostPerSquareFoot}, {saveOrder.MaterialCost}, {saveOrder.LaborCost}, {saveOrder.Tax},{saveOrder.Total}";

                            sw.WriteLine(row);
                        }
                    }              
                }

            }
            return true;
        }

        public bool SaveNewOrder(Order order)
        {
            List<Order> orderList = LookupOrders(order.Date);
            order.OrderNumber = (orderList.Count > 0) ? orderList.Max(l => l.OrderNumber) + 1 : 1;
            orderList.Add(order);

            string header = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";

            string orderString = "Orders_";

            string userInput = DirectoryPath + orderString + String.Format(order.Date.ToString("MMddyyyy")) + ".txt";

            using (StreamWriter sw = new StreamWriter(userInput))
            {
                sw.WriteLine(header);

                foreach(var singleOrder in orderList)
                {
                    Order orderToSave = singleOrder;

                    string row = $"{orderToSave.OrderNumber},{orderToSave.CustomerName},{orderToSave.State},{orderToSave.TaxRate}," +
                        $"{orderToSave.ProductType},{orderToSave.Area},{orderToSave.CostPerSquareFoot}," +
                        $"{orderToSave.LaborCostPerSquareFoot},{orderToSave.MaterialCost}," +
                        $"{orderToSave.LaborCost},{orderToSave.Tax},{orderToSave.Total}";

                    sw.WriteLine(row);
                }
            }
            return true;
        }
    }
}
