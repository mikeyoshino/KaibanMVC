using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kaiban.Models;

namespace Kaiban.Controllers
{
    public class CitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cities
        public ActionResult Index()
        {
            var cities = db.Cities.ToList();

            return View(cities);
        }

        public ActionResult Add()
        {
            var cities = new City();
            return View(cities);
        }

        [HttpPost]
        public ActionResult Add(City city)
        {
            db.Cities.Add(city);
            db.SaveChanges();

            return View("Index", "Cities");
        }
    }
}