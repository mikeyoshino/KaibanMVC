using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kaiban.Models
{
    [NotMapped]
    public class Search
    {

        public int? Id { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string County { get; set; }



    }
    [NotMapped]
    public class ProductBusinessLogic
    {
        private ApplicationDbContext Context;
        public ProductBusinessLogic()
        {
            Context = new ApplicationDbContext();
        }


        //คลาสที่ใช้ในการค้นหารายชื่อโฆษณา
        public IQueryable<Ads> GetProducts(Search searchModel)
        {
            var result = Context.Adses.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.Id.HasValue)
                    result = result.Where(x => x.Id == searchModel.Id);

                //เช็คว่า SreetName มีค่ส่งมาหรือปล่าวเเล้ว ค้นหาจากฐานข้อมูลโดยกำหนด StreetName ของ Search Model ตรงกับชื่อถนนไหนบ้างในฐานข้อมูล;
                if (!string.IsNullOrEmpty(searchModel.Category))
                    result = result.Where(x => x.Category.Name.Contains(searchModel.Category));

                if (!string.IsNullOrEmpty(searchModel.County))
                    result = result.Where(x => x.County.Name.Contains(searchModel.County));

                if (!string.IsNullOrEmpty(searchModel.City))
                    result = result.Where(x => x.City.Name.Contains(searchModel.City));
            }
            return result;
        }
    }
}