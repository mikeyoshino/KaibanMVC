using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kaiban.Models
{
    public class County
    {
        public int Id { get; set; }

        [Display(Name = "ชื่อเขตหรืออำเภอ")]
        public string Name { get; set; }

        [Display(Name = "จังหวัดที่เขตอยู่")]
        public int CityId { get; set; }
        public City City { get; set; }

        public ICollection<Ads> Adses { get; set; }
    }
}