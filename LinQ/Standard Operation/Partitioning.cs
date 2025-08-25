using static LinQ.Data.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace LinQ.Standard_Operation
{
    public class Partitioning
    {
        public void Show()
        {
            // Take(n): Get the first n elements
            var firstTwoCustomer = Customers.Take(2);
            Console.WriteLine($"First two customer: ");
            foreach(var c in firstTwoCustomer)
                Console.WriteLine(c.Name);
            Console.WriteLine();

            // Skip(n): Skip the first n elements
            var skipCustomer = Customers.Skip(2);
            Console.WriteLine($"Ship first two customer: ");
            foreach(var c in skipCustomer)
                Console.WriteLine(c.Name);
            Console.WriteLine();

            // TakeWhile(condition): Take until condition is false
            var shortOrders = Customers
                .Where(c => c.Orders != null)
                .SelectMany(c => c.Orders.Select(o => new
                {
                    CustomerName = c.Name,
                    Days = (o.DateStart - o.DateEnd).TotalDays
                }))
                .OrderBy(x => x.Days)
                .TakeWhile(x => x.Days <= 3);
            foreach (var c in shortOrders)
                Console.WriteLine($"Customer {c.CustomerName} has a {c.Days} order");
            Console.WriteLine();

            // SkipWhile(condition): Skip until condition is false
            var expensiveProduct = AllProducts
                .Select(c => new
                {
                    Name = c.Name,
                    Price = c.Price
                })
                .OrderBy(x => x.Price)
                .SkipWhile(x => x.Price <= 300);
            Console.WriteLine("Expensive product");
            foreach (var c in expensiveProduct)
                Console.WriteLine($"{c.Name} - {c.Price}");
            Console.WriteLine();
        }
    }
}
