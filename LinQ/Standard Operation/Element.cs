using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static LinQ.Data.Datas;

namespace LinQ.Standard_Operation
{
    public class Element
    {
        public void Show()
        {
            // First(): Get the first element, error if there is no elements
            var firstOrderWithProduct = Customers
                .Where(c => c.Name == "Bob")
                .SelectMany(c => c.Orders)
                .Join(
                    AllProducts,
                    order => order.ProductId,
                    product => product.Id,
                    (order, product) => new
                    {
                        order.ProductId,
                        ProductName = product.Name
                    })
                .First();
            Console.WriteLine($"First order of Bob: Product: {firstOrderWithProduct.ProductName}");

            // FirstOrDefault(): Get the first element, return default(T) if empty (null for reference types)
            var longOrder = Customers
                .Where(c => c.Orders != null)
                .SelectMany(c => c.Orders)
                .Where(o => (o.DateEnd - o.DateStart).TotalDays > 7)
                .Join(
                    AllProducts,
                    order => order.ProductId,
                    product => product.Id,
                    (order, product) => new
                    {
                        order.ProductId,
                        ProductName = product.Name
                    })
                .FirstOrDefault();
            if (longOrder != null)
                Console.WriteLine($"Long order: Product: {longOrder.ProductName}");
            else
                Console.WriteLine("No long order found.");
            Console.WriteLine();

            // Last(), LastOrDefault(): Same as First, FirstOrDefault but get the last element
            var lastOrderOfBob = Customers
                .Where(c => c.Name == "Bob" && c.Orders != null)
                .SelectMany(c => c.Orders)
                .OrderBy(c => c.DateStart)
                .Join(
                    AllProducts,
                    order => order.ProductId,
                    product => product.Id,
                    (order, product) => new {order, product})
                .Join(
                    Stores,
                    op => op.order.StoreId,
                    store => store.Id,
                    (op, store) => new
                    {
                        ProductId = op.order.ProductId,
                        ProductName = op.product.Name,
                        StoreName = store.Name
                    })
                .LastOrDefault();
            if (lastOrderOfBob != null)
            {
                Console.WriteLine($"Last order of Bob: ProductId = {lastOrderOfBob.ProductId}, ProductName = {lastOrderOfBob.ProductName}, StoreName = {lastOrderOfBob.StoreName}");
            }
            else
            {
                Console.WriteLine("Bob has no orders.");
            }
            Console.WriteLine();

            // ElementAt(index): Get element at index position, error if range is exceeded
            // ElementAtOrDefault(index): Same as ElementAt, return default(T) if empty (null for reference types)
            var index = 2;
            var orderWithDetails = Customers
                .Where(c => c.Orders != null)
                .SelectMany(c => c.Orders, (customer, order) => new { customer, order })
                .Join(
                    AllProducts,
                    co => co.order.ProductId,
                    product => product.Id,
                    (co, product) => new { co.customer, co.order, product }
                )
                .Join(
                    Stores,
                    cop => cop.order.StoreId,
                    store => store.Id,
                    (cop, store) => new
                    {
                        CustomerName = cop.customer.Name,
                        ProductName = cop.product.Name,
                        StoreName = store.Name,
                        StartDate = cop.order.DateStart
                    }
                )
                .ElementAtOrDefault(index);

            if (orderWithDetails != null)
            {
                Console.WriteLine($"Order {index}:");
                Console.WriteLine($"- Customer: {orderWithDetails.CustomerName}");
                Console.WriteLine($"- Product: {orderWithDetails.ProductName}");
                Console.WriteLine($"- Store: {orderWithDetails.StoreName}");
                Console.WriteLine($"- StartDate: {orderWithDetails.StartDate}");
            }
            else
            {
                Console.WriteLine($"No order found at index {index}.");
            }
            Console.WriteLine();

            // Single(): return only element that statisfies the condition, if there is none or more than one, throw exception
            // SingleOrDefault(): Same as Single, but return default(T) if there is none, if more than one throw exception
            var orderOfSully = Customers
                .Where(c => c.Name == "Sully")
                .SelectMany(c => c.Orders, (customer, order) => new { customer, order })
                .Join(
                    AllProducts,
                    co => co.order.ProductId,
                    product => product.Id,
                    (co, product) => new { co.customer, co.order, product }
                )
                .Join(
                    Stores,
                    cop => cop.order.StoreId,
                    store => store.Id,
                    (cop, store) => new
                    {
                        CustomerName = cop.customer.Name,
                        ProductName = cop.product.Name,
                        StoreName = store.Name,
                        StartDate = cop.order.DateStart
                    }
                )
                .SingleOrDefault();
            Console.WriteLine("Order of Sully");
            if (orderOfSully != null)
            {
                Console.WriteLine($"- Customer: {orderOfSully.CustomerName}");
                Console.WriteLine($"- Product: {orderOfSully.ProductName}");
                Console.WriteLine($"- Store: {orderOfSully.StoreName}");
                Console.WriteLine($"- Start Date: {orderOfSully.StartDate}");
            }
            else
            {
                Console.WriteLine("Eve has no orders or has multiple orders.");
            }
            Console.WriteLine();
        }
    }
}
