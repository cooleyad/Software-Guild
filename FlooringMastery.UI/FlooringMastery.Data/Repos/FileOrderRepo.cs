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
        public const string directoryPath = @"\\Mac\Home\Desktop\Sample Data\";

        public const string header = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot," +
                "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";

        public const string orderString = "Orders_";

        FileTaxRepo fileTaxRepo = new FileTaxRepo();
        FileProductRepo fileProductRepo = new FileProductRepo();


        public bool DeleteOrder(Order order)
        {
            List<Order> orderList = LookupOrders(order.Date);

            orderList.Remove(order);

            string orderString = "Orders_";

            string userInput = directoryPath + orderString + String.Format(order.Date.ToString("MMddyyyy")) + ".txt";

            using (StreamWriter sw = new StreamWriter(userInput))
            {
                sw.WriteLine(header);

                foreach (var singleOrder in orderList)
                {
                    if (singleOrder.OrderNumber == order.OrderNumber)
                    {

                    }
                    else
                    {
                        string row = $"{singleOrder.OrderNumber},{singleOrder.CustomerName},{singleOrder.State}," +
                            $"{singleOrder.TaxData},{singleOrder.ProductType},{singleOrder.Area},{singleOrder.CostPerSquareFoot}," +
                            $"{singleOrder.LaborCostPerSquareFoot},{singleOrder.MaterialCost},{singleOrder.LaborCost}," +
                            $"{singleOrder.Tax},{singleOrder.Total}";

                        sw.WriteLine(row);
                    }
                }

            }
            return true;
        }

        public Order LookupOrder(DateTime time, int orderNumber)
        {
            var dailyOrders = LookupOrders(time);

            var selectedOrder = dailyOrders.SingleOrDefault(s => s.OrderNumber == orderNumber);

            return selectedOrder;
        }

        public List<Order> LookupOrders(DateTime time)
        {
            List<Order> orderList = new List<Order>();

            string userInput = directoryPath + orderString + string.Format(time.ToString("MMddyyyy")) + ".txt";


            using (StreamReader sr = new StreamReader(userInput))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Order order = new Order();

                    string[] columns = line.Split(',');

                    order.OrderNumber = int.Parse(columns[0]);
                    order.CustomerName = columns[1];
                    order.State = columns[2];
                    order.TaxData= decimal.Parse(columns[3]);
                    order.ProductType=(columns[4]);
                    order.Area=decimal.Parse(columns[5]);
                    order.CostPerSquareFoot = decimal.Parse(columns[6]);
                    order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);

                    order.Date = time;

                    orderList.Add(order);
                }
            }
            return orderList;
        }

        public bool SaveExistingOrder(Order order)
        {
            List<Order> orderList = LookupOrders(order.Date);

            orderList.Remove(order);

            string userInput = directoryPath + orderString + String.Format(order.Date.ToString("MMddyyyy")) + ".txt";

            using (StreamWriter sw = new StreamWriter(userInput))
            {

                foreach (var anOrder in orderList)
                {
                    Order saveOrder = anOrder;
                    {
                        sw.WriteLine(header);

                        if (anOrder.OrderNumber == order.OrderNumber)
                        {
                            saveOrder = order;
                        }
                        {
                            string row = $"{saveOrder.OrderNumber},{saveOrder.CustomerName}," +
                                   $"{saveOrder.State},{saveOrder.TaxData},{saveOrder.ProductType},{saveOrder.Area}," +
                                   $"{saveOrder.CostPerSquareFoot},{saveOrder.LaborCostPerSquareFoot},{saveOrder.MaterialCost}," +
                                   $"{saveOrder.LaborCost},{saveOrder.Tax},{saveOrder.Total}";

                            sw.WriteLine(row);
                        }
                    }
                }
            }
            return true;
        }

        public bool SaveNewOrder(Order order)
        {

            string userInput = directoryPath + orderString + String.Format(order.Date.ToString("MMddyyyy")) + ".txt";

            if (File.Exists(userInput))
            {
                List<Order> orderList = LookupOrders(order.Date);
                if (orderList.Count == 0)
                {
                    order.OrderNumber = 1;
                }
                else
                {
                    order.OrderNumber = (orderList.Count > 0) ? orderList.Max(l => l.OrderNumber) + 1 : 1;
                    orderList.Add(order);

                    using (StreamWriter sw = new StreamWriter(userInput))
                    {

                        foreach (var singleOrder in orderList)
                        {
                            Order orderToSave = singleOrder;

                            string row = $"{orderToSave.OrderNumber},{orderToSave.CustomerName},{orderToSave.State},{orderToSave.TaxData}," +
                                $"{orderToSave.ProductType},{orderToSave.Area},{orderToSave.CostPerSquareFoot}," +
                                $"{orderToSave.LaborCostPerSquareFoot},{orderToSave.MaterialCost}," +
                                $"{orderToSave.LaborCost},{orderToSave.Tax},{orderToSave.Total}";
                            sw.WriteLine(row);
                        }
                    }

                }           
            }
            else
            {
                using (File.Create(userInput)) { }

                using (StreamWriter saving = new StreamWriter(userInput))
                {
                    saving.WriteLine(header);

                    saving.WriteLine("1," + order.CustomerName + "," + order.State + "," + order.TaxData
                           + "," + order.ProductType + "," + order.Area + "," + order.CostPerSquareFoot + "," + order.LaborCostPerSquareFoot
                           + "," + order.MaterialCost + "," + order.LaborCost + "," + order.Tax + "," + order.Total);
                }
            }
            return true;
        }
    }
}
