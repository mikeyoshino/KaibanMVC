using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaiban.Models
{
    public class AdsImage
    {
        public int Id { get; set; }

        public byte[] ImageData { set; get; }

        public Ads Ads { get; set; }
        public int AdsId { get; set; }
    }
}