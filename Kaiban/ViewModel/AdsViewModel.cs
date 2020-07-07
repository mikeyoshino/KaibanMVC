using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kaiban.Models;

namespace Kaiban.ViewModel
{
    public class AdsViewModel
    {
        public Ads Ads { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<AdsImage> AdsImages { get; set; }
        public List<ApplicationUser> ApplicationUser { get; set; }
        public IEnumerable<County> Counties { get; set; }
    }
}