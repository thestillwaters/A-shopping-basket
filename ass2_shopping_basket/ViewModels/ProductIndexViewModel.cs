using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ass2_shopping_basket.Models;
using System.Web.Mvc;
using PagedList;
//lab4 24 mins create new obj
namespace ass2_shopping_basket.ViewModels
{
    public class ProductIndexViewModel
    {
        //lab5
        public IPagedList<Product> Products { get; set; }

        //public IQueryable<Product> Products { get; set; }
        public string Search { get; set; }
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; }
        public string Category { get; set; }

        //lab5
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }
        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CategoryName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }
    }

    public class CategoryWithCount
    {
        public int ProductCount { get; set; }
        public string CategoryName { get; set; }
        public string CatNameWithCount
        {
            get
            {
                return CategoryName + " (" + ProductCount.ToString() + ")";
            }
        }
    }
}