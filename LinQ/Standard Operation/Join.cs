using LinQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinQ.Data.Datas;

namespace LinQ.Standard_Operation
{
    public class Join
    {
        public void Show()
        {
            // Join: combine two data sets according to a common condition
            var orderWithDetail = Customers
                .Where(c => c.Orders != null)
                .SelectMany(c => c.Orders, (customer, order) => new { customer, order })
                .Join(
                    Stores.SelectMany(s => s.Products, (store, product) => new { store, product }),
                    co => new { co.order.ProductId, co.order.StoreId },
                    sp => new { ProductId = sp.product.Id, StoreId = sp.store.Id },
                    (co, sp) => new
                    {
                        CustomerName = co.customer.Name,
                        ProductName = sp.product.Name,
                        StoreName = sp.store.Name,
                        StoreLocation = sp.store.Location,
                        OrderDays = (co.order.DateEnd - co.order.DateStart).TotalDays
                    });

            //Query syntax
            var orderWithDetail2 = from customer in Customers
                                   where customer.Orders != null
                                   from order in customer.Orders
                                   join storeProduct in
                                        (from store in Stores
                                         from product in store.Products
                                         select new { store, product })
                                   on new { order.ProductId, order.StoreId }
                                   equals new { ProductId = storeProduct.product.Id, StoreId = storeProduct.store.Id }
                                   select new
                                   {
                                       CustomerName = customer.Name,
                                       ProductName = storeProduct.product.Name,
                                       StoreName = storeProduct.store.Name,
                                       StoreLocation = storeProduct.store.Location,
                                       OrderDays = (order.DateEnd - order.DateStart).TotalDays
                                   };

            foreach(var o in orderWithDetail)
                Console.WriteLine($"{o.CustomerName} ordered {o.ProductName} at {o.StoreName} in {o.StoreLocation} for {o.OrderDays} days");

            // GroupJoin: combine elements from 2 sets and group by key
            var customerWithOrders = Customers
                .GroupJoin(
                    Customers.SelectMany(c => c.Orders ?? Enumerable.Empty<Order>(), (c, o) => new { c.Id, Order = o }),
                    customer => customer.Id,
                    orderInfo => orderInfo.Id,
                    (customer, orders) => new
                    {
                        CustomerName = customer.Name,
                        Orders = orders.Select(o => new
                        {
                            ProductId = o.Order.ProductId,
                            StoreId = o.Order.StoreId,
                            Days = (o.Order.DateEnd - o.Order.DateStart).TotalDays
                        })
                    });

            // Query syntax
            var customerWithOrders2 = from customer in Customers
                                      join orderInfo in
                                            (from c in Customers
                                             from o in c.Orders ?? Enumerable.Empty<Order>()
                                             select new { c.Id, Order = o })
                                      on customer.Id equals orderInfo.Id into customerOrders
                                      select new
                                      {
                                          Customer = customer.Name,
                                          Orders = from o in customerOrders
                                                   select new
                                                   {
                                                       ProductId = o.Order.ProductId,
                                                       StoreId = o.Order.StoreId,
                                                       Days = (o.Order.DateEnd - o.Order.DateStart).TotalDays
                                                   }
                                      };

            foreach (var c in customerWithOrders)
            {
                Console.WriteLine($"Customer: {c.CustomerName}");
                foreach (var order in c.Orders)
                {
                    Console.WriteLine($"  Ordered ProductId {order.ProductId} at StoreId {order.StoreId} for {order.Days} days");
                }
            }
            Console.WriteLine();

            // LeftJoin:combine elements from 2 sets and group by key
            // Retain all records from the left , even if there are no corresponding records from the right
            var leftJoin = Customers
                .GroupJoin(
                    Customers.SelectMany(c => c.Orders ?? Enumerable.Empty<Order>(), (c, o) => new { c.Id, Order = o }),
                    c => c.Id,
                    co => co.Id,
                    (c, orderGroup) => new
                    {
                        Customer = c,
                        Orders = orderGroup
                    })
                    .SelectMany(
                    co => co.Orders.DefaultIfEmpty(),
                    (co, order) => new
                    {
                        CustomerId = co.Customer.Id,
                        CustomerName = co.Customer.Name,
                        OrderInfo = order?.Order == null
                        ? "No order"
                        : $"ProductId: {order.Order.ProductId}, StoreId: {order.Order.StoreId}"
                    }
                );
            Console.WriteLine("List of customer - order");
            foreach (var item in leftJoin)
            {
                Console.WriteLine($"Customer {item.CustomerId} - {item.CustomerName} => {item.OrderInfo}");
            }
            Console.WriteLine();
        }
    }
}
