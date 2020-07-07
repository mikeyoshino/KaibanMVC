using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Kaiban.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "ประเภท")]
        public string Name { get; set; }

        [Display(Name = "ไอคอน")]
        public string ImagePath { get; set; }

        [Display(Name = "คำอธิบาย")]
        public string Description { get; set; }

        public ICollection<Ads> Adses { get; set; }
    }
}