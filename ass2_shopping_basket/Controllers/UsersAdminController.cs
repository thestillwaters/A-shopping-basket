﻿using ass2_shopping_basket.Models;
using ass2_shopping_basket.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ass2_shopping_basket.Controllers
{
    //lab7b
    [Authorize(Roles = "Admin")]
    public class UsersAdminController : Controller
    {
        public UsersAdminController()
        { }
        public UsersAdminController(ApplicationUserManager userManager,
        ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        } 
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ??
                HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }



        // GET: UsersAdmin
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: UsersAdmin
        public async Task<ActionResult> Index()
        {
            return View(await UserManager.Users.ToListAsync());
        }

        // GET: UsersAdmin/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            ViewBag.RoleNames = await UserManager.GetRolesAsync(user.Id);
            return View(user);
        }

        // GET: UsersAdmin/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        public async Task<ActionResult> Create()
        {
            //Get the list of the roles
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(),
            "Name", "Name");
            return View();
        }



        // POST: UsersAdmin/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //lab7b
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params
string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    DateOfBirth = userViewModel.DateOfBirth,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    Address = userViewModel.Address
                };
                var adminresult = await UserManager.CreateAsync(user,
                userViewModel.Password);
                //Add user to the selected roles
                if (adminresult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await UserManager.AddToRolesAsync(user.Id,
                        selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            ViewBag.RoleId = new SelectList(await
                            RoleManager.Roles.ToListAsync(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First());
                    ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name",
                    "Name");
                    return View();
                }
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
            return View();
        }

        // GET: UsersAdmin/Edit/5
        //    public ActionResult Edit(int id)
        //{
        //    return View();
        //}



        //lab7c
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userRoles = await UserManager.GetRolesAsync(user.Id);
            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                RolesList = RoleManager.Roles.ToList().Select(x => new
                SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }

        // POST: UsersAdmin/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel editUser, params
string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                user.DateOfBirth = editUser.DateOfBirth;
                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.Address = editUser.Address;
                var userRoles = await UserManager.GetRolesAsync(user.Id);
                selectedRole = selectedRole ?? new string[] { };
                var result = await UserManager.AddToRolesAsync(user.Id,
                selectedRole.Except(userRoles).ToArray<string>());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                result = await UserManager.RemoveFromRolesAsync(user.Id,
                userRoles.Except(selectedRole).ToArray<string>());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }



        // GET: UsersAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
