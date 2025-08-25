using static LinQ.Data.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LinQ.Standard_Operation
{
    public class Projection
    {
        public void Show()
        {
            // Select: Select and transform each element in the list into another value (keep original structure)
            var customerName = Customers.Select(c => c.Name);
            var customerNameAndAge = Customers.Select(c => new
            {
                Name = c.Name,
                Age = c.Age
            });

            // Query syntax
            var customerNameAndAge2 = from c in Customers
                                      select new
                                      {
                                          Name = c.Name,
                                          Age = c.Age
                                      };
            Console.WriteLine($"Name of all customer: ");
            foreach(var name in customerName)
                Console.WriteLine(name);
            Console.WriteLine($"Name and Age of all customer: ");
            foreach (var c in customerNameAndAge)
                Console.WriteLine($"{c.Name} - {c.Age}");
            Console.WriteLine();

            // SelectMany: flatten nested list into a single list
            var allProducts = Stores.SelectMany(c => c.Products);
            Console.WriteLine("All products: ");
            foreach (var product in allProducts)
                Console.WriteLine($"{product.Name} - {product.Price}");

            var allOrders = Customers
                .Where(c => c.Orders != null)
                .SelectMany(c => c.Orders.Select(o => new
                {
                    CustomerName = c.Name,
                    o.DateStart,
                    o.DateEnd,
                }));

            //Query syntax
            var allOrders2 = from c in Customers
                             where c.Orders != null
                             from o in c.Orders
                             select new
                             {
                                 CustomerName = c.Name,
                                 o.DateStart,
                                 o.DateEnd
                             };

            Console.WriteLine("Customer order: ");
            foreach (var order in allOrders)
                Console.WriteLine($"Customer {order.CustomerName} order at {order.DateStart.ToShortTimeString}");
            Console.WriteLine();
        }
    }
}
