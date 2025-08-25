using LinQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.Other_Method
{
    public class Concat
    {
        public void Show()
        {
            var americaCustomers = Datas.Customers.Where(c => c.Country == "America");
            var englandCustomers = Datas.Customers.Where(c => c.Country == "England");

            var allSelected = americaCustomers.Concat(englandCustomers);

            Console.WriteLine("Concat example: ");
            foreach (var c in allSelected)
            {
                Console.WriteLine($"{c.Name} - {c.Country}");
            }
        }
    }
}
