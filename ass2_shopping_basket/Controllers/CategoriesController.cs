using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ass2_shopping_basket.Models;
using ass2_shopping_basket.ViewModels;
using PagedList;


namespace ass2_shopping_basket.Controllers
{

    //lab7c
    [Authorize(Roles = "Admin")]


    public class CategoriesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Categories
        //
        // public ActionResult Index()
        //{
        //return View(db.Categories.ToList());
        //lab4 Sorting Categories Alphabetically
        //return View(db.Categories.OrderBy(c => c.Name).ToList());
        // }

        [AllowAnonymous]
        public ActionResult Index()
        {
            // return View(db.Categories.ToList());
            //For sorting categories alphabetically
            return View(db.Categories.OrderBy(c => c.Name).ToList());
        }


        //    public ActionResult Index(int? page)
        //{
        //    var cats = db.Categories.OrderBy(cat => cat.Name);
        //    CategoryIndexViewModel viewModel = new CategoryIndexViewModel();
        //    //6 item per page
        //    const int PageItems = 6;
        //    int CurrentPage = (page ?? 1);
        //    viewModel.Categories = cats.ToPagedList(CurrentPage, PageItems);
        //    return View(viewModel);
        //} 


        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            //lab5
            foreach (var p in category.Products)
            {
                p.CategoryID = null; 
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }  

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
