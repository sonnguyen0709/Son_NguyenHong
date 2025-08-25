using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static LinQ.Data.Datas;

namespace LinQ.Standard_Operation
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(Product obj)
        {
            return obj.Id.GetHashCode();
        }
    }
    public class SetOperation
    {
        public void Show()
        {
            // Distinct: Remove duplicate elements
            var distinctProductNames = Stores
                .SelectMany(store => store.Products)
                .Select(p => p.Name)
                .Distinct();
            Console.WriteLine("Distice product in all store: ");
            foreach (var name in distinctProductNames)
                Console.WriteLine($"Product: {name}");

            var storeAProducts = Stores
                .Where(s => s.Name == "Store1")
                .SelectMany(s => s.Products)
                .Select(p => p.Name);
            var storeBProducts = Stores
                .Where(s => s.Name == "Store2")
                .SelectMany(s => s.Products)
                .Select(p => p.Name);

            // Union: Union of two sets (remove duplicate)
            var unionProducts = storeAProducts.Union(storeBProducts);
            foreach (var name in unionProducts)
                Console.WriteLine($"Product: {name}");

            // Intersect: intersection of two sets (same values)
            var intersectProducts = storeAProducts.Intersect(storeBProducts);
            foreach (var name in intersectProducts)
                Console.WriteLine($"Product: {name}");

            // Except: set effect (only in list 1, not in list 2)
            var exceptProducts = storeAProducts.Except(storeBProducts);
            foreach (var name in exceptProducts)
                Console.WriteLine($"Only in Store A: {name}");

            // With object
            var allProducts = Stores
                .SelectMany(s => s.Products)
                .Distinct(new ProductComparer());
            foreach (var p in allProducts)
                Console.WriteLine($"Product: {p.Name} (Id: {p.Id})");
        }
    }
}
