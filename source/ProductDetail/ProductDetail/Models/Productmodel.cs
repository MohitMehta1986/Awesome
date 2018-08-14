using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetail.Models
{
    public class Productmodel
    {
        public string productID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
    }

    public class Productcoll
    {
        public List<Productmodel> coll { get; set; }
        public Productmodel Productentity { get; set; }
    }
}
