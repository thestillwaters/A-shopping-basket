using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using ass2_shopping_basket.Models;

//lab5 end 
namespace ass2_shopping_basket.ViewModels
{
    public class CategoryIndexViewModel
    {
        public IPagedList<Category> Categories { get; set; }

    }
}