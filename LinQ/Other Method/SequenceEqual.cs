using LinQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.Other_Method
{
    public class SequenceEqual
    {
        public void Show()
        {
            var store1Products = Datas.Stores.FirstOrDefault(s => s.Id == 1)
                .Products.Select(p => p.Id);
            var store3Products = Datas.Stores.FirstOrDefault(s => s.Id == 3)
                .Products.Select(p => p.Id);

            bool isSame = store1Products.SequenceEqual(store3Products);

            Console.WriteLine("SequenceEqual example: ");
            Console.WriteLine($"Store1 vs Store3: {(isSame ? "Same Product" : "Different Products")}");
        }
    }
}
