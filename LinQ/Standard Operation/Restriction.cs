using static LinQ.Data.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.Standard_Operation
{
    public class Restriction
    {
        public void Show()
        {
            // Where : filter data from a set (List, Array, IEnumerable, ...)
            // Method syntax
            var americanCustomer = Customers.Where(c => c.Country == "America");

            // Query syntax
            var americaStore = from s in Stores
                               where s.Location == "America"
                               select s;

            // Nested Where
            var americanCustomerAndAge = Customers.Where(c => c.Country == "America")
                .Where(c => c.Age > 15);
            Console.WriteLine("America Customer: ");
            foreach(var c in americanCustomer)
                Console.WriteLine($"{c.Name} - {c.Age}");
            foreach (var c in americaStore)
                Console.WriteLine($"{c.Name}");
            foreach (var c in americanCustomerAndAge)
                Console.WriteLine($"{c.Name} - {c.Age}");
        }
    }
}
