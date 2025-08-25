using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static LinQ.Data.Datas;

namespace LinQ.Standard_Operation
{
    public class Grouping
    {
        public void Show()
        {
            // GroupBy: to group by one or more keys
            var productWithStore = Stores
                .SelectMany(s => s.Products.Select(p => new { Product = p, Store = s }))
                .GroupBy(p => p.Product.Name)
                .Select(g => new
                {
                    ProductName = g.Key,
                    StoreName = g.Select(x => x.Store.Name).Distinct()
                });

            // Query syntax
            var productWithStore2 = from s in Stores
                                    from p in s.Products
                                    group new { s, p } by p.Name into g
                                    select new
                                    {
                                        ProductName = g.Key,
                                        StoreName = g.Select(x => x.s.Name).Distinct()
                                    };

            foreach (var group in productWithStore)
                Console.WriteLine($"{group.ProductName} is sold at: {string.Join(", ", group.StoreName)}");
            Console.WriteLine();

            // GroupBy with many keys
            var pageNumber = 2;
            var pageSize = 3;
            var productWithPriceInStore = Stores
                .SelectMany(store => store.Products.Select(p => new { Product = p, Store = store }))
                .GroupBy(x => new { x.Product.Name, x.Product.Price })
                .Select(g => new
                {
                    ProductName = g.Key.Name,
                    ProductPrice = g.Key.Price,
                    StoreName = g.Select(x => x.Store.Name).Distinct()
                })
                .OrderBy(g => g.ProductName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // Query syntax
            var productWithPriceInStore2 = (from s in Stores
                                            from p in s.Products
                                            group new {s, p} by new {p.Name, p.Price} into g
                                            let storeName = g.Select(x => x.s.Name).Distinct()
                                            orderby g.Key.Name
                                            select new
                                            {
                                                ProductName = g.Key.Name,
                                                ProductPrice = g.Key.Price,
                                                StoreName = storeName
                                            })
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize);

            foreach (var group in productWithPriceInStore)
                Console.WriteLine($"Product: {group.ProductName}, Price: {group.ProductPrice}, Sold at: {string.Join(", ", group.StoreName)}");
            Console.WriteLine();
        }
    }
}
