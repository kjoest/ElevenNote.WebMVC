﻿using ElevenNote.Data;
using ElevenNote.Models.CategoryModels;
using ElevenNote.Services.CategoryServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers.CategoryController
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Category
        public ActionResult Index()
        {
            var service = CreateCategoryService();
            var model = service.GetCategory();
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            //var viewModel = new CategoryCreate();
            //viewModel.Notes = _db.Notes.Select(note => new SelectListItem
            //{
            //    Text = note.Title,
            //    Value = note.NoteId.ToString()
            //});
            return View(/*viewModel*/);
        }

        //POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            var service = CreateCategoryService();

            if (!ModelState.IsValid)
                return View(model);


            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your category was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be created.");
            return View(model);

            //if (ModelState.IsValid)
            //{
            //    _db.Categories.Add(model);
            //    if (_db.SaveChanges() == 1)
            //    {
            //        return Redirect("/Category");
            //    }
            //    ViewData["ErrorMessage"] = "Couldn't save your categories.";
            //}
            //ViewData["ErrorMessage"] = "Model state was invalid";

            //var viewModel = new CategoryCreate();
            //viewModel.Notes = _db.Notes.Select(note => new SelectListItem
            //{
            //    Text = note.Title,
            //    Value = note.NoteId.ToString()
            //});

            //return View(model);
        }

        // GET: Category/{id}
        public ActionResult Details(int id)
        {
            var service = CreateCategoryService();
            var model = service.GetCategoryById(id);

            if(model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);
        }

        // GET: Category/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            var model = service.GetCategoryById(id);

            return View(model);
        }

        // POST: Category/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            //var category = _db.Categories.Find(id);
            //if(category != null)
            //{
            //    _db.Categories.Remove(category);
            //    TempData["SaveResult"] = "Your category was deleted.";
            //    return RedirectToAction("Index");
            //}

            //ModelState.AddModelError("", "Your category could not be delete.");
            //return View(category);

            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Category/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateCategoryService();
            var entity = service.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    CategorId = entity.CategoryId,
                    CategoryName = entity.CategoryName
                };

            if (model == null)
                return HttpNotFound();

            return View(model);

        }

        // POST: Category/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            //if (ModelState.IsValid)
            //{
            //    _db.Entry(category).State = EntityState.Modified;
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(category);

            if (!ModelState.IsValid)
                return View(model);

            if(model.CategorId != id)
            {
                ModelState.AddModelError("", "ID Mistatch");
                return View(model);             
            }

            var service = CreateCategoryService();

            if (service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your category was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your category could not be updated.");
            return View(model);

        }

        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }
    }
}