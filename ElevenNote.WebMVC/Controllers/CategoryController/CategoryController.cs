using ElevenNote.Data;
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
        public ActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        // POST: Category/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Category/Edit/{id}
        public ActionResult Edit(int? id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
                return HttpNotFound();

            ViewData["Notes"] = _db.Notes.Select(note => new SelectListItem
            {
                Text = note.Content,
                Value = note.NoteId.ToString()
            });

            return View(category);
        }

        // POST: Category/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryEdit category)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(category).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }
    }
}