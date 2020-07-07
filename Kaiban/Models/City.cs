using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Kaiban.Models
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "ชื่อจังหวัด")]
        [Required]
        public string Name { get; set; }


        [Display(Name = "เปอรเช็นขึ้นต่อปี")]
        [Required]
        public int IncreasePY { get; set; }

        [Display(Name = "ราคาต่อตารางวา")]
        [Required]
        public double PricePerSqureMeter { get; set; }

        public ICollection<Ads> Adses { get; set; }

        public ICollection<County> Counties { get; set; }
    }
}