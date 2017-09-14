using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();


            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            Exercise30();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var filtered = DataLoader.LoadProducts();

            filtered = filtered.Where(p => p.UnitsInStock < 1).ToList();

            PrintProductInformation(filtered);


        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> costThree = DataLoader.LoadProducts();

            var cost = costThree.Where(c => c.UnitPrice >= 3M && c.UnitsInStock >= 1);

            PrintProductInformation(cost);

        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customer = DataLoader.LoadCustomers();

            var filtered = from c in customer
                           where c.Region == "WA"
                           select c;
            PrintCustomerInformation(filtered);

        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var prodName = from p in DataLoader.LoadProducts()
                           select new { ProductName = p.ProductName };

            foreach (var product in prodName)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> theProducts = DataLoader.LoadProducts();

            var print = from p in theProducts
                        select new
                        {
                            p.ProductName,
                            p.Category,
                            markup = p.UnitPrice * 0.25M + p.UnitPrice,
                            p.ProductID,
                            p.UnitsInStock
                        };

            foreach (var list in print)
            {
                Console.WriteLine(list);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> nameCat = DataLoader.LoadProducts();

            var list = from p in nameCat
                       select new { Category = p.Category, productName = p.ProductName };

            foreach (var index in nameCat)
            {
                Console.WriteLine(index.Category.ToUpper());
                Console.WriteLine(index.ProductName.ToUpper());
                Console.WriteLine();

            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> theProducts = DataLoader.LoadProducts();

            string lineFormat = "{0,-15}{1,-35}{2,-20}{3,-15:C}{4,-20}{5,-15}";

            var reprint = from p in theProducts
                          select new { p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock, ReOrder = p.UnitPrice < 3 ? true : false };

            foreach (var print in reprint)
            {
                Console.WriteLine(lineFormat, print.ProductID, print.ProductName, print.Category, print.UnitPrice, print.UnitsInStock, print.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> theProducts = DataLoader.LoadProducts();
            var print = from p in theProducts
                        select new
                        {
                            p.ProductName,
                            p.ProductID,
                            p.Category,
                            p.UnitPrice,
                            p.UnitsInStock,
                            StockValue = p.UnitPrice * p.UnitsInStock
                        };

            foreach (var info in print)
            {
                Console.WriteLine(info);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var onlyEvens = DataLoader.NumbersA.Where(n => n % 2 == 0);

            foreach (var n in onlyEvens)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> orderInfo = DataLoader.LoadCustomers();

            var filtered = from customer in orderInfo

                           where customer.Orders.Any(o => o.Total < 500)
                           select customer;

            PrintCustomerInformation(filtered);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var firstThree = DataLoader.NumbersC.Where(n => n % 2 == 1).Take(3);

            foreach (var i in firstThree)
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var afterThree = DataLoader.NumbersB.Skip(3);

            foreach (var i in afterThree)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> custInfo = DataLoader.LoadCustomers();
            var customers = custInfo.Where(c => c.Region == "WA").Select(c =>
                new { p = c.CompanyName, d = c.Orders.OrderByDescending(o => o.OrderDate).First() });

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.p + "||" + customer.d.OrderDate);

            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var sixer = DataLoader.NumbersC.Where(n => n < 6);

            foreach (var i in sixer)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var threeve = DataLoader.NumbersC;

            foreach (var n in threeve.SkipWhile(n => n % 3 != 0 || n == 3))
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> alpha = DataLoader.LoadProducts();
            alpha = alpha.OrderBy(p => p.ProductName).ToList();

            PrintProductInformation(alpha);


        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> stock = DataLoader.LoadProducts();
            stock = stock.OrderByDescending(p => p.UnitsInStock).ToList();

            PrintProductInformation(stock);

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> product = DataLoader.LoadProducts();

            var sortedproducts =
                from p in product
                orderby p.Category, p.UnitPrice descending
                select p;

            PrintProductInformation(sortedproducts);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var backwards = DataLoader.NumbersB.Reverse();

            foreach (int i in backwards)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var groups = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in groups)
            {
                Console.WriteLine();
                Console.WriteLine("Category: {0}", group.Key);
                Console.WriteLine("==========================================");

                foreach (var p in group)
                {
                    Console.WriteLine(p.ProductName);
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        //static void Exercise21()
        //{

        //}

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> categories = DataLoader.LoadProducts();
            var print = categories.Select(c => c.Category).Distinct();

            foreach (var info in print)
            {
                Console.WriteLine(info);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();

            var exists =
                from product in products
                where product.ProductID == 789
                select product;

            PrintProductInformation(exists);
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.Where(p => p.UnitsInStock == 0).Select(p => p.Category).Distinct();

            foreach (var i in filtered)
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.Where(p => p.UnitsInStock >= 1).Select(p => p.Category).Distinct();

            foreach (var i in filtered)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var odds = DataLoader.NumbersA.Count(n => n % 2 == 1);

            Console.WriteLine(odds);

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> orderCount = DataLoader.LoadCustomers();
            var count = from c in orderCount
                        select new { custID = c.CustomerID, custOrd = c.Orders.Count() };
            {
                foreach (var d in count)
                {
                    Console.WriteLine(d);
                }
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filtered = from p in products
                           group p by p.Category into d
                           select new { cat = d.Key, count = d.Count() };

            foreach (var i in filtered)
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {

            List<Product> products = DataLoader.LoadProducts();

            var filtered = from p in products
                           group p by p.Category into d
                           select new { cat = d.Key, count = d.Sum(c => c.UnitsInStock) };

            foreach (var i in filtered)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filtered = from p in products
                           group p by p.Category into g
                           select new { cat = g.Key, low = g.OrderBy(c => c.UnitPrice).First() };

            foreach (var i in filtered)
            {
                Console.WriteLine($"{i.cat}, {i.low.ProductName}");
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var avgPrice = DataLoader.LoadProducts().GroupBy(p => p.Category)
                               .Select(p => new
                               {
                                   category = p.Key,
                                   average = p.Average(cl => cl.UnitPrice)
                               })
                               .OrderByDescending(P => P.average).Take(3);



            String line = "{0, -35}{1, -30:c}";
            Console.WriteLine(line, "Product Category", "Lowest Price");
            Console.WriteLine("==========================================================");

            foreach (var k in avgPrice)

            {
                Console.WriteLine(line, k.category, k.average);
            }
        }
    }
}
