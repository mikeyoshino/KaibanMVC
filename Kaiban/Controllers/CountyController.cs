using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kaiban.Models;
using Kaiban.ViewModel;

namespace Kaiban.Controllers
{
    public class CountyController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: County
        public ActionResult Index()
        {
            var county = db.Counties.ToList();
            return View(county);
        }

        public ActionResult Add()
        {
            var cities = db.Cities.ToList();
            var viewModel = new CountyViewModel
            {
                City = cities,
                County = new County()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(County county)
        {
            db.Counties.Add(county);
            db.SaveChanges();
            return RedirectToAction("Add", "County");

        }
    }
}