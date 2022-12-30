using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nike_vn.Models;

namespace Nike_vn.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index(int? id)
        {
            NikeDBContext db = new NikeDBContext();
            Product product = db.Products.Where(row => row.ProductId == id).FirstOrDefault();
            List<Store> stores = db.Stores.Where(row => row.Product.ProductId == product.ProductId && row.ProductSize.ApparelId == product.ApparelId).ToList();

            ViewBag.StoreLst = stores;
            ViewBag.LstCount = stores.Count();

            return View(product);
        }
    }
}