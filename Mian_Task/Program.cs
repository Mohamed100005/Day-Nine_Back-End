using Mian_Task.Data;

namespace Mian_Task {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            ApplicationDbContext applicationDbContext = new();
            //Retrieve all categories from the production.categories table.
            var categories = applicationDbContext.Categories;
            foreach (var category in categories) {
                Console.WriteLine($"Id:{category.CategoryId} Name:{category.CategoryName}");
            }

            //Retrieve the first product from the production.products table.
            var products = applicationDbContext.Products.Skip(0).Take(1);
            foreach (var product in products) {
                Console.WriteLine(product.ProductId + product.ProductName);
            }

            //Retrieve a specific product from the production.products table by ID.
            var productsId = applicationDbContext.Products.Find(2);
            Console.WriteLine(productsId.ProductName);

            //Retrieve all products from the production.products table with a certain model year.
            var productModel = applicationDbContext.Products.Where(e => e.ModelYear == 2016);
            foreach (var item in productModel) {
                Console.WriteLine(item.ProductName);
            }

            //Retrieve a specific customer from the sales.customers table by ID.
            var customers = applicationDbContext.Customers.FirstOrDefault(e => e.CustomerId == 5);
            Console.WriteLine(customers.FirstName);

            //Retrieve a list of product names and their corresponding brand names.
            var products2 = applicationDbContext.Products.Select(e => new { e.ProductName, e.Brand.BrandName });
            foreach (var item in products2) {
                Console.WriteLine($"{item.ProductName} + {item.BrandName}");
            }

            //Count the number of products in a specific category.
            var productsCount = applicationDbContext.Products.Where(e => e.Category.CategoryName == "Electric Bikes").Count();
            Console.WriteLine(productsCount);

            //Calculate the total list price of all products in a specific category.
            var productsPrice = applicationDbContext.Products.Where(e => e.Category.CategoryName == "Electric Bikes").Sum(e => e.ListPrice);
            Console.WriteLine(productsPrice);

            //Calculate the average list price of products.
            var productsPriceAvg = applicationDbContext.Products.Where(e => e.Category.CategoryName == "Electric Bikes").Average(e => e.ListPrice);
            Console.WriteLine(productsPriceAvg);

            //Retrieve orders that are completed.
            var ordersStatus = applicationDbContext.Orders.Where(e => e.OrderStatus == 4);
            foreach (var order in ordersStatus) {
                Console.WriteLine(order.OrderId);
            }
        }
    }
}
