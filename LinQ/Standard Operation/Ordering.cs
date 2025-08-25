using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinQ.Data.Datas;

namespace LinQ.Standard_Operation
{
    public class Ordering
    {
        public void Show()
        {
            // OrderBy: Sort ascending by a key
            // ThenBy: Sub-sorts (ascending) after OrderBy
            var customerByCountryThenName = Customers
                .OrderBy(c => c.Country)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    Name = c.Name,
                    Country = c.Country
                });

            // Query syntax
            var customerByCountryThenName2 =
                from c in Customers
                orderby c.Country, c.Name
                select new
                {
                    Name = c.Name,
                    Country = c.Country
                };

            Console.WriteLine("OrderBy, ThenBy: ");
            foreach (var c in customerByCountryThenName)
                Console.WriteLine($"{c.Country} - {c.Name}");
            Console.WriteLine();

            // OrderByDescending: Sort descending by a key
            // ThenByDescending: Sub-sort (descending) after OrderBy
            var allOrders = Customers
                .Where(c => c.Orders != null)
                .SelectMany(c => c.Orders, (customer, order) => new
                {
                    CustomerName = customer.Name,
                    order.DateStart,
                    order.DateEnd,
                    Duration = (order.DateEnd - order.DateStart).TotalDays
                })
                .OrderByDescending(o => o.DateStart)
                .ThenByDescending(o => o.Duration);

            // Query syntax
            var allOrders2 = from c in Customers
                             where c.Orders != null
                             from order in c.Orders
                             let Duration = (order.DateEnd - order.DateStart).TotalDays
                             orderby order.DateStart descending, Duration descending
                             select new
                             {
                                 CustomerName = c.Name,
                                 order.DateStart,
                                 order.DateEnd,
                                 Duration
                             };

            Console.WriteLine("OrderByDescending, ThenByDescending: ");
            foreach (var o in allOrders)
                Console.WriteLine($"{o.CustomerName} - Start: {o.DateStart.ToShortDateString()}, Duration: {o.Duration} days");
            Console.WriteLine();

            // Reverse: Reverses the current order of the data series
            var reversedCustomers = Customers
                .Select(c => c.Name)
                .Reverse();

            Console.WriteLine("Original: ");
            foreach (var c in Customers)
                Console.WriteLine(c.Name);
            Console.WriteLine();
            Console.WriteLine("Reverse: ");
            foreach (var c in reversedCustomers)
                Console.WriteLine(c);
            Console.WriteLine();
        }
    }
}
