using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kaiban.Models
{
    public class Ads
    {
        public int Id { get; set; }

        [Display(Name = "หัวข้อ")]
        [Required]
        public string AdsName { get; set; }


        [Display(Name = "ประเภท")]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        //Property details
        [Display(Name = "จำนวนห้องนอน")]
        [Required]
        public byte BedRoom { get; set; }

        [Display(Name = "จำนวนห้องน้ำ")]
        [Required]
        public byte BathRoom { get; set; }

        [Display(Name = "ขนาดบ้าน")]
        [Required]
        public int SquareMetre { get; set; }

        [Display(Name = "จำนวนที่จอดรถ")]
        [Required]
        public int Garage { get; set; }

        [Display(Name = "ฟอนิเจอร์")]
        public bool IsFurnished { get; set; }


        [Display(Name = "เขต / อำเภอ")]
        [Required]
        public int CountyId { get; set; }
        public County County { get; set; }


        [Display(Name = "จังหวัด")]
        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        [Display(Name = "รหัสไปรษณีย์")]
        public byte PostCode { get; set; }

        [Display(Name = "คำอธิบาย")]
        public string Description { get; set; }

        [Display(Name = "ราคา")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Price { get; set; }


        public DateTime PostDate { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public string Poster { get; set; }

        public ICollection<AdsImage> AdsImage { get; set; }

    }


}