using LinQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.Other_Method
{
    public class Zip
    {
        public void Show()
        {
            var discounts = new[] { 0.1m, 0.2m, 0.05m, 0.15m, 0.25m, 0.3m, 0.35m };

            var productDiscounts = Datas.AllProducts.Zip(discounts,
                (product, discount) => new
                {
                    ProductName = product.Name,
                    OldPrice = product.Price,
                    Discount = discount,
                    NewPrice = product.Price * (1 - discount)
                });

            Console.WriteLine("Zip example: ");
            foreach (var item in productDiscounts)
            {
                Console.WriteLine($"{item.ProductName}: {item.OldPrice} -> {item.NewPrice} (Discount {item.Discount * 100}%)");
            }
        }
    }
}
