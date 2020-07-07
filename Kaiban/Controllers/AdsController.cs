using Kaiban.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kaiban.ViewModel;
using Microsoft.AspNet.Identity;

namespace Kaiban.Controllers
{
    public class AdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            var AdsList = db.Adses.ToList();
            return View(AdsList);
        }


        public ActionResult Search()
        {
            var search = new Search();
            return View(search);
        }


        public ActionResult SearchAds(Search searchModel)
        {
            var business = new ProductBusinessLogic();
            var model = business.GetProducts(searchModel);
            return View(model);
        }

        public ActionResult Add()
        {
            List<City> lstcCities = db.Cities.ToList();
            lstcCities.Insert(0, new City { Id = 0, Name = "Choose City" });

            List<County> lstCounties = db.Counties.ToList();
            lstCounties.Insert(0, new County { Id = 0, Name = "Choose County" });

            ViewBag.CityId = new SelectList(lstcCities, "Id", "Name");
            ViewBag.CountyId = new SelectList(lstCounties, "Id", "Name");

            var category = db.Categories.ToList();
            var cities = db.Cities.ToList();
            var counties = db.Counties.ToList();
            var viewModel = new AdsViewModel
            {
                Cities = cities,
                Category = category,
                Counties = counties

            };

            return View("Add", viewModel);
        }
        [HttpPost]
        public ActionResult Add(Ads ads, IEnumerable<HttpPostedFileBase> images, HttpPostedFileBase ImageFile)
        {

            //Ensure model state is valid  
            if (ModelState.IsValid)
            {
                //check if images is null
                if (images != null)
                {
                    var imageList = new List<AdsImage>();
                    foreach (var image in images) //Loop for images for multiple uploading.
                    {
                        using (var br = new BinaryReader(image.InputStream))
                        {
                            var data = br.ReadBytes(image.ContentLength);
                            var img = new AdsImage { AdsId = ads.Id };
                            img.ImageData = data;
                            imageList.Add(img);
                        }
                    }
                    ads.AdsImage = imageList;
                }

                //Upload poster

                ////Add image to database
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                ads.Poster = "/Images/Ads_Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Images/Ads_Image/"), fileName);
                ImageFile.SaveAs(fileName);


                ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", ads.CityId);
                ViewBag.CountyId = new SelectList(db.Counties, "Id", "Name", ads.CountyId);

                var userID = User.Identity.GetUserId();
                ads.ApplicationUserId = userID;
                ads.PostDate = DateTime.Now;
                db.Adses.Add(ads);
                db.SaveChanges();

                TempData["SM"] = "คุณได้เพิ่มรายการเรียบร้อย!";

            }

            return RedirectToAction("Add", "Ads");
        }


        //สเก็บค่ารายชื่อเขตจากการเลือกจังหวัด
        public JsonResult GetCountyByCityId(int id)
        {
            List<County> counties = new List<County>();

            if (id > 0)
            {
                counties = db.Counties.Where(p => p.CityId == id).ToList();

            }
            else
            {
                counties.Insert(0, new County() { Id = 0, Name = "กรุณาเลือกจังหวัดก่อน" });
            }

            var result = (from r in counties
                select new
                {
                    id = r.Id,
                    name = r.Name
                }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdsDetail(int id)
        {
            var ads = db.Adses.Find(id);
            var cat = db.Categories.ToList();
            var city = db.Cities.ToList();
            var counties = db.Counties.ToList();
            var image = db.AdsImage.Where(i => i.AdsId == id);

            //Get User individual ID
            var userID = User.Identity.GetUserId();

            //Get User detail based on given User Id
            var userDetail = db.Users.Where(a => a.Id == userID).ToList();
            var viewModel = new AdsViewModel()
            {
                Ads = ads,
                Category = cat,
                Cities = city,
                AdsImages = image,
                ApplicationUser = userDetail,
                Counties = counties

            };

            

            return View(viewModel);

        }
    }
}