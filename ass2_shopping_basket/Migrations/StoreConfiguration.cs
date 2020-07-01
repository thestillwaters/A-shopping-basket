namespace ass2_shopping_basket.Migrations.StoreConfiguration
{
    using Models;
    using System.Collections.Generic; 
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class StoreConfiguration : DbMigrationsConfiguration<ass2_shopping_basket.Models.StoreContext>
    {
        public StoreConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //lab5
        protected override void Seed(ass2_shopping_basket.Models.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var categories = new List<Category> {
            new Category {Name = "Caps" },
            new Category {Name = "Football jerseys" },
            new Category {Name = "NBA jerseys" },
            new Category {Name = "Sneaker shoes" },
            };
             categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var products = new List<Product> { 
            new Product {Name = "Chicago Bulls cap",    Description = "Men's New Era Chicago Bulls NBA Draft Official",     Price =  50, CategoryID= categories.Single(c=>c.Name == "Caps").ID},
            new Product {Name = "Phila ers cap",      Description = "Core Adjustable and it is the counterpart of the THIRTY",  Price =  40, CategoryID= categories.Single(c=>c.Name == "Caps").ID },
            new Product {Name = "Holland jersey",       Description = "Extremely rare shirt  worn in qualification for Euro", Price = 230, CategoryID= categories.Single(c=>c.Name == "Football jerseys").ID},
            new Product {Name = "Barcelona jersey",     Description = "FC Barcelona Vapor Match Home a unique design",  Price = 180, CategoryID= categories.Single(c=>c.Name == "Football jerseys").ID},
            new Product {Name = "Allen Iverson Jersey", Description = "Phila Allen Iverson Home Authentic Jersey", Price = 250, CategoryID= categories.Single(c=>c.Name == "NBA jerseys").ID},
            new Product {Name = "Kevin Garnett Jersey", Description = "Minnesota Timberwolves Kevin Garnett Swingman Jersey",     Price = 190, CategoryID= categories.Single(c=>c.Name == "NBA jerseys").ID},
            new Product {Name = "Jason Williams Jersey",Description = "Sacramento Kings J Williams HardwoodRoad Swingman Jersey", Price = 150, CategoryID= categories.Single(c=>c.Name == "NBA jerseys").ID},
            new Product {Name = "Air Jordan One",         Description = "Inspired by Air Jordan from his first season", Price = 180, CategoryID= categories.Single(c=>c.Name == "Sneaker shoes").ID},
            new Product {Name = "Air Jordan Eleven",        Description = "It features Jordans return from retirement",  Price = 230, CategoryID= categories.Single(c=>c.Name == "Sneaker shoes").ID},
            new Product {Name = "Air Jordan Thirteen",        Description = "In the season Jordan outmaneuvered his rivals",   Price = 260, CategoryID= categories.Single(c=>c.Name == "Sneaker shoes").ID},
              };
            products.ForEach(c => context.Products.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            //lab8b
            var orders = new List<Order> {
                new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street",Town="Town1",Country="Country", PostCode="PostCode" }, TotalPrice=631,UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 1) ,DeliveryName="Admin" },
                new Order { DeliveryAddress = new Address { AddressLine1="2 Some Street",Town="Town1",Country="Country", PostCode="PostCode" }, TotalPrice=239,UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 2) ,DeliveryName="Admin" },
                new Order { DeliveryAddress = new Address { AddressLine1="3 Some Street",Town="Town1",Country="Country", PostCode="PostCode" }, TotalPrice=239,UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 3) ,DeliveryName="Admin" },
                new Order { DeliveryAddress = new Address { AddressLine1="4 Some Street",Town="Town1",Country="County", PostCode="PostCode" }, TotalPrice=631,UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 4) ,DeliveryName="Admin" },
                new Order { DeliveryAddress = new Address { AddressLine1="5 Some Street",Town="Town1",Country="Country", PostCode="PostCode" }, TotalPrice=19,UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 5) ,DeliveryName="Admin" }
            };
            orders.ForEach(c => context.Orders.AddOrUpdate(o => o.DateCreated, c));
            context.SaveChanges();

            var orderLines = new List<OrderLine> {
                new OrderLine { OrderID = 1, ProductID = products.Single( c=> c.Name =="Allen Iverson Jersey").ID,ProductName ="Allen Iverson Jersey", Quantity =1, UnitPrice=products.Single( c=>c.Name == "Allen Iverson Jersey").Price },
                new OrderLine { OrderID = 2, ProductID = products.Single( c=> c.Name == "Kevin Garnett Jersey").ID,ProductName="Kevin Garnett Jersey", Quantity=1, UnitPrice=products.Single( c=> c.Name=="Kevin Garnett Jersey").Price },
                new OrderLine { OrderID = 3, ProductID = products.Single( c=> c.Name == "Air Jordan One").ID,ProductName ="Air Jordan One", Quantity=1, UnitPrice=products.Single( c=>c.Name == "Air Jordan One").Price },
                new OrderLine { OrderID = 4, ProductID = products.Single( c=> c.Name =="Air Jordan Eleven").ID,ProductName ="Air Jordan Eleven", Quantity=1, UnitPrice=products.Single( c=>c.Name == "Air Jordan Eleven").Price },
                new OrderLine { OrderID = 5, ProductID = products.Single( c=> c.Name =="Air Jordan Thirteen").ID,ProductName ="Air Jordan Thirteen", Quantity=1, UnitPrice=products.Single(c=> c.Name == "Air Jordan Thirteen").Price }
            };
            orderLines.ForEach(c => context.OrderLines.AddOrUpdate(ol => ol.OrderID, c));
            context.SaveChanges();

        }
    }
}
