using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinQ.Data.Datas;

namespace LinQ.Standard_Operation
{
    public class Conversion
    {
        public void Show()
        {
            // ToList(): convert to List()
            // ToDictionary(): convert to Dictionary() (key must be unique, otherwise runtime error)
            // ToArray(): convert to Array[]
            // OfType<T>(): Filter out elements of type T from the list
            var storeAProducts = Stores
                .Where(s => s.Name == "Store A")
                .SelectMany(s => s.Products)
                .ToArray();
            Console.WriteLine("To array: ");
            foreach(var p in storeAProducts)
                Console.WriteLine($"Product: {p.Name}");

            var longOrders = Customers
                .Where(c => c.Orders != null)
                .SelectMany(c => c.Orders)
                .Where(o => (o.DateEnd - o.DateStart).TotalDays > 2)
                .ToList();
            Console.WriteLine("To List: ");
            foreach (var o in longOrders)
                Console.WriteLine($"Order: ProductId {o.ProductId}, Days: {(o.DateEnd - o.DateStart).TotalDays}");

            var productDict = Stores
                .SelectMany(s => s.Products)
                .GroupBy(p => p.Id)
                .ToDictionary(p => p.Key, p => p.First().Name);
            Console.WriteLine("To dictionary: ");
            foreach (var kv in productDict)
                Console.WriteLine($"Id: {kv.Key}, Name: {kv.Value}");

            var mixed = new object[] { "A", 1, "B", 2.5, "C", 3.5, 3 };
            var strings = mixed.OfType<string>();
            var ints = mixed.OfType<int>();
            var doubles = mixed.OfType<double>();
            Console.WriteLine("OfType<string>: ");
            foreach (var s in strings)
                Console.WriteLine(s);
            Console.WriteLine("OfType<int>: ");
            foreach (var s in ints)
                Console.WriteLine(s);
            Console.WriteLine("OfType<double>: ");
            foreach (var s in doubles)
                Console.WriteLine(s);
        }
    }
}
