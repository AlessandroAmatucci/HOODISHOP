using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoodiShop.Models.Entities
{
    public class Beat
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string filename { get; set; }

        public bool isOwned { get; set; }
        public string owner { get; set; }
    }
}