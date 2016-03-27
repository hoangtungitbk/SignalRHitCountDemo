using HitCountDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HitCountDemo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public JsonResult GetAllProduct()
        {
            var model =  ProductRepository.GetAllProduct();
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult CreateProduct(Product product)
        {
            ProductRepository.AddProduct(product);
            return new JsonResult() { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
	}
}