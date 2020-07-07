using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kaiban.Models;

namespace Kaiban.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Category
        public ActionResult Index()
        {
            var category = db.Categories.ToList();

            return View(category);
        }

        public ActionResult Add()
        {
                var category = new Category();
                return View(category);


        }

        [HttpPost]
        public ActionResult Add(Category category, HttpPostedFileBase ImageFile)
        {
            if (!ModelState.IsValid)
            {
                var cat = new Category();
                return View("Add", cat);
            }

            if (category.Id == 0)
            {
                //Add image to database
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                category.ImagePath = "~/Images/Icon/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Images/Icon/"), fileName);

                ImageFile.SaveAs(fileName);
                db.Categories.Add(category);

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Category");
        }
    }
}