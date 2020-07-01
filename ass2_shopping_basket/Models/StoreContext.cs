using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ass2_shopping_basket.Models
{
    public class StoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StoreContext() : base("name=StoreContext")
        {
        }

        public System.Data.Entity.DbSet<ass2_shopping_basket.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ass2_shopping_basket.Models.Product> Products { get; set; }

        //lab6b images
        public System.Data.Entity.DbSet<ass2_shopping_basket.Models.ProductImage> ProductImages { get; set; }

        //lab6c
        public System.Data.Entity.DbSet<ass2_shopping_basket.Models.ProductImageMapping> ProductImageMappings { get; set; }
        //lab8a
        public System.Data.Entity.DbSet<ass2_shopping_basket.Models.BasketLine> BasketLines { get; set; }
        //lab8b
        public System.Data.Entity.DbSet<ass2_shopping_basket.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<ass2_shopping_basket.Models.OrderLine> OrderLines { get; set; }

    }
}
