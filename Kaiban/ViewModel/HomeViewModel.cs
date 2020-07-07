using Kaiban.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaiban.ViewModel
{
    public class HomeViewModel
    {
        public List<Ads> Ads { get; set; }
        public AdsImage AdsImages { get; set; }
        public List<Category> Category { get; set; }
        public List<City> Cities { get; set; }
        public List<County> Counties { get; set; }


        //ViewModel for _AdSeach paritrial view.
        public Search Search { get; set; }
    }
}