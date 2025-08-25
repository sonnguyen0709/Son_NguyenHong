using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinQ.Data;

namespace LinQ.Standard_Operation
{
    public class Generation
    {
        public void Show()
        {
            // Enumerable.Range(int start, int count): Generates a sequence of consecutive integers, starting from "start", has "count" numbers
            var table = Enumerable.Range(2, 8)
                .SelectMany(x => Enumerable.Range(1, 10)
                .Select(y => $"{x} x {y} = {x * y}")
                );
            Console.WriteLine("Multiplication table: ");
            foreach (var line in table)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();

            // Enumberable.Repeat<T>(T element, int count): repeats the same "element" value, "count" times
            var repeatOrders = Enumerable.Repeat(
                new Datas.Order
                {
                    ProductId = 1,
                    StoreId = 1,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddDays(3)
                },3);

            Console.WriteLine("Repeat orders: ");
            foreach (var o in repeatOrders)
                Console.WriteLine($"{o.ProductId} - {o.StoreId}");
        }
    }
}
