using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinQ.Data.Datas;

namespace LinQ.Standard_Operation
{
    public class Aggregate
    {
        public void Show()
        {
            // Count(): Count the number of elements that satisfy a condition or all
            // Sum(), Min(), Max(), Average(): calculate sum, find smallest value, find largest value, calculate average
            int totalProduct = AllProducts.Count();
            Console.WriteLine($"Total product: {totalProduct}");

            int expensiveProduct = AllProducts.Count(p => p.Price > 500);
            Console.WriteLine($"Total product have price more than 500: {expensiveProduct} product");

            decimal totalPrice = AllProducts.Sum(p =>  p.Price);
            Console.WriteLine($"Total price: {totalPrice}");

            decimal minPrice = AllProducts.Min(p => p.Price);
            decimal maxPrice = AllProducts.Max(p => p.Price);
            Console.WriteLine($"Lowest price: {minPrice}\nHighest price: {maxPrice}");

            double avgRating = AllProducts.Average(p => p.Rating);
            Console.WriteLine($"Average rating: {avgRating}");

            // Aggregate()
            // var result = source.Aggreate((acc, item) => ...)
            // acc: Interim results after each step, item: The current element in the list
            // return a single value after processing entire list
            // var result = source.Aggregate(seed, (acc, item) => ...) Can pass initialization value (seed)
            var productName = AllProducts
                .Select(p => p.Name)
                .Aggregate((a, b) => $"{a}, {b}");
            Console.WriteLine($"List of product: {productName}");

            var longestNameProduct = AllProducts
                .Aggregate((longest, next) => next.Name.Length > longest.Name.Length ? next : longest);
            Console.WriteLine($"Longest name product: {longestNameProduct.Name}");
        }
    }
}
