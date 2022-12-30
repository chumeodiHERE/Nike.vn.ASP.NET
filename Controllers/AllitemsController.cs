using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nike_vn.Models;

namespace Nike_vn.Controllers
{
    public class AllitemsController : Controller
    {
        // GET: Allitems
        public ActionResult Index(string search="", int page=1)
        {
            NikeDBContext db = new NikeDBContext();
            List<Product> products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.ControlName = "allitems";
            ViewBag.ActionName = "index";
            ViewBag.Search = search;
            ViewBag.QuantityProDuct = products.Count();

            //Pagin
            int NoOfRecordPerPage = 9;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;

            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(products);
        }
    }
}