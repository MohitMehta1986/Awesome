using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductDetail.Models;

namespace ProductDetail.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(Productcoll model)
        {
            //model = new Productcoll { Productentity = new Productmodel { productID = "1", Price = "50", ProductName = "test" }, coll = new List<Productmodel> { new Productmodel { productID = "1", Price = "50", ProductName = "test" } } };
            DataAccessLayes.GetData obj1 = new DataAccessLayes.GetData();
            model.coll = obj1.InsertRecord(model.Productentity);

            
            return View(model);
        }
    }
}