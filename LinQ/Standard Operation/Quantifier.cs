using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinQ.Data.Datas;

namespace LinQ.Standard_Operation
{
    public class Quantifier
    {
        public void Show()
        {
            // Any(condition): return true if at least one element satisfies the condition
            // Any(): return true if the list has at least 1 element
            bool customerWithoutOrder = Customers.Any(c => c.Orders == null || !c.Orders.Any());
            Console.WriteLine($"Are there any customers without orders: " + (customerWithoutOrder ? "Yes" : "No"));
            Console.WriteLine();

            bool hasHighRated = AllProducts.Any(p => p.Rating >= 4.5);
            Console.WriteLine($"Are there any products with rating > 4.5: " + (hasHighRated ? "Yes" : "No"));
            Console.WriteLine();

            // All(condition): return true if all elements satisfy the condition
            bool allShortOrder = Customers
                .Where(c => c.Name == "Bob")
                .SelectMany(c => c.Orders)
                .All(o => (o.DateEnd - o.DateStart).TotalDays < 7);
            Console.WriteLine($"All of Bob's orders are under 7 days: " + (allShortOrder ? "Yes" : "No"));
            Console.WriteLine();

            // Contains: Check if a list contains a specific element
            var productIdInOrder = Customers
                .Where(c => c.Orders != null)
                .SelectMany(c => c.Orders)
                .Select(o => o.ProductId)
                .Distinct()
                .ToList();
            var hasProduct = productIdInOrder.Contains(10);
            Console.WriteLine($"Is the product with Id = 10 sold: " + (hasProduct ? "Yes" : "No"));
            Console.WriteLine();
        }
    }
}
