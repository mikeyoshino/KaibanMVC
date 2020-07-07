using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kaiban.Models;
using Kaiban.ViewModel;

namespace Kaiban.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            var ads = db.Adses.ToList();
            var image = db.AdsImage.FirstOrDefault();
            var cat = db.Categories.ToList();
            var city = db.Cities.ToList();
            var counties = db.Counties.ToList();
            var viewModel = new HomeViewModel()
            {
                Ads = ads,
                AdsImages = image,
                Category = cat,
                Cities = city,
                Counties = counties
 
            };
 

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LastedAds ()
        {
            int numberOfrecords=10;
            
            var ads = db.Adses.ToList();
            var image = db.AdsImage.FirstOrDefault();
            var cat = db.Categories.ToList();
            var city = db.Cities.ToList();
            var result = ads.OrderByDescending(x => x.PostDate).Take(numberOfrecords);

            var viewModel = new HomeViewModel()
            {
                Ads = ads,
                AdsImages = image,
                Category = cat,
                Cities = city

            };


            return PartialView(result);
        }
    }
}