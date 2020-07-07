using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kaiban.Models;

namespace Kaiban.ViewModel
{
    public class CountyViewModel
    {
        public County County { get; set; }
        public IEnumerable<City> City { get; set; }
    }
}