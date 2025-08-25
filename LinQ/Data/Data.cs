using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.Data
{
    public class Datas
    {
        public class Student
        {
            public string Name;
            public List<string> Subjects;
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public double Rating { get; set; }
        }

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }
            public int Age { get; set; }
            public IEnumerable<Order> Orders { get; set; }
        }

        public class Store
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public IEnumerable<Product> Products { get; set; }
        }

        public class Order
        {
            public DateTime DateStart { get; set; }
            public DateTime DateEnd { get; set; }
            public int ProductId { get; set; }
            public int StoreId { get; set; }
        }

        public static Product[] AllProducts => new[]
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Description = "Gaming laptop", Rating = 4.5 },
            new Product { Id = 2, Name = "Phone", Price = 500, Description = "Smartphone", Rating = 4.0 },
            new Product { Id = 3, Name = "Mouse", Price = 50, Description = "Wireless mouse", Rating = 4.2 },
            new Product { Id = 4, Name = "KeyBoard", Price = 120, Description = "KeyboardPc", Rating = 4.3 },
            new Product { Id = 5, Name = "Mornitor", Price = 300, Description = "Mornitor", Rating = 4.4 },
            new Product { Id = 6, Name = "Screen", Price = 300, Description = "PcScreen", Rating = 4.6 },
        };
        public static Store[] Stores => new[]
        {
            new Store
            {
                Id = 1,
                Name = "Store1",
                Location = "America",
                Products = AllProducts.Where(p => new[] {1, 3, 5}.Contains(p.Id)).ToList()
            },
            new Store
            {
                Id = 2,
                Name = "Store2",
                Location = "England",
                Products = AllProducts.Where(p => new[] {4, 5, 6}.Contains(p.Id)).ToList()
            },
            new Store
            {
                Id = 3,
                Name = "Store3",
                Location = "Germany",
                Products = AllProducts.Where(p => new[] {1, 3, 5, 6}.Contains(p.Id)).ToList()
            }
        };
        public static Customer[] Customers => new[]
        {
            new Customer
            {
                Id = 1,
                Name = "Bob",
                Country = "America",
                Age = 15,
                Orders = new List<Order>
                {
                    new Order { ProductId = 1, StoreId = 1, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(5) },
                    new Order { ProductId = 2, StoreId = 1, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(2) }
                }
            },
            new Customer
            {
                Id = 2,
                Name = "Mike",
                Country = "England",
                Age = 14,
                Orders = new List<Order>
                {
                    new Order { ProductId = 4, StoreId = 2, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(5) },
                    new Order { ProductId = 5, StoreId = 2, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(2) }
                }
            },
            new Customer
            {
                Id = 3,
                Name = "Jack",
                Country = "Germany",
                Age = 20,
                Orders = new List<Order>
                {
                    new Order { ProductId = 1, StoreId = 3, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(5) },
                    new Order { ProductId = 6, StoreId = 3, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(2) }
                }
            },
            new Customer 
            {
                Id = 3,
                Name = "Jake",
                Country = "America",
                Age = 19,
                Orders = new List<Order>
                {
                    new Order { ProductId = 1, StoreId = 1, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(5) },
                    new Order { ProductId = 5, StoreId = 2, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(4) },
                    new Order { ProductId = 3, StoreId = 3, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(6) }
                }
            },
            new Customer 
            {
                Id = 4, 
                Name = "Sully", 
                Country = "America", 
                Age = 21,
                Orders = new List<Order>
                {
                    new Order { ProductId = 5, StoreId = 1, DateStart = DateTime.Today, DateEnd = DateTime.Today.AddDays(5) }
                }
            },
            new Customer { Id = 5, Name = "Karl", Country = "England", Age = 14 },
            new Customer { Id = 6, Name = "Taylor", Country = "England", Age = 16 },
            new Customer { Id = 7, Name = "Sue", Country = "America", Age = 19 },
            new Customer { Id = 8, Name = "John", Country = "England", Age = 23 },
            new Customer { Id = 9, Name = "Mark", Country = "Germany", Age = 18 }
        };
    }
}
