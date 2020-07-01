 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ass2_shopping_basket
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        { 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //lab6 create before Index
            routes.MapRoute(
                name: "ProductsCreate",
                url: "Products/Create",
                defaults: new { controller = "Products", action = "Create" }
                );


            //route for paging on category page, merged ProductsbyPage and ProductsByCategory
            routes.MapRoute(
              name: "ProductsbyCategoryByPage",
              url: "Products/{category}/Page{page}",
              defaults: new { controller = "Products", action = "Index" }
              );

            // route for paging on products page
            routes.MapRoute(
               name: "ProductsbyPage",
               url: "Products/Page{page}",
               defaults: new { controller = "Products", action = "Index" }
               );

            routes.MapRoute(
                name: "ProductsByCategory",
                url: "Products/{category}",
                defaults: new { controller = "Products", action = "Index" }
                );
            //match with @using (Html.BeginRouteForm("ProductsIndex", FormMethod.Get))
            //from Products Index.cshtml
            routes.MapRoute(
              name: "ProductsIndex",
              url: "Products",
              defaults: new { controller = "Products", action = "Index" }
              );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
