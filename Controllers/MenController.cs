using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nike_vn.Models;

namespace Nike_vn.Controllers
{
    public class MenController : Controller
    {
        // GET: Men
        public ActionResult AllShoes(string id, int page=1)
        {
            NikeDBContext db = new NikeDBContext();
            List<Product> products = db.Products.Where(row => row.ProductGenderId == 1 && row.ApparelId == 1).ToList();
            ViewBag.Heading = "Men's Shoes";
            ViewBag.ControlName = "men";
            ViewBag.ActionName = "allshoes";
            ViewBag.QuantityProDuct = products.Count();
            if (id == null)
            {
                //Pagin
                int noOfRecordPerPage = 9;
                int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(noOfRecordPerPage)));
                int noOfRecordToSkip = (page - 1) * noOfRecordPerPage;

                ViewBag.Page = page;
                ViewBag.NoOfPages = noOfPages;

                products = products.Skip(noOfRecordToSkip).Take(noOfRecordPerPage).ToList();

                return View("Shop", products);
            }
            switch (id)
            {
                case "lowhigh":
                    products = products.OrderBy(row => row.ProductPrice).ToList();
                    break;
                case "highlow":
                    products = products.OrderByDescending(row => row.ProductPrice).ToList();
                    break;
                case "50-100":
                    products = products.Where(row => row.ProductPrice >= 50 && row.ProductPrice <= 100).ToList();
                    break;
                case "100-150":
                    products = products.Where(row => row.ProductPrice >= 100 && row.ProductPrice <= 150).ToList();
                    break;
                case "over-150":
                    products = products.Where(row => row.ProductPrice >= 150).ToList();
                    break;
            }

            //Pagin
            int NoOfRecordPerPage = 9;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;

            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View("Shop", products);
        }

        public ActionResult FootballShoes(string id, int page = 1)
        {
            NikeDBContext db = new NikeDBContext();
            List<Product> products = db.Products.Where(row => row.ProductGenderId == 1 && row.ApparelId == 1 && row.CategoryId == 1).ToList();
            ViewBag.Heading = "Men's Football Shoes";
            ViewBag.ControlName = "men";
            ViewBag.ActionName = "footballshoes";
            ViewBag.QuantityProDuct = products.Count();
            if (id == null)
            {
                //Pagin
                int noOfRecordPerPage = 9;
                int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(noOfRecordPerPage)));
                int noOfRecordToSkip = (page - 1) * noOfRecordPerPage;

                ViewBag.Page = page;
                ViewBag.NoOfPages = noOfPages;

                products = products.Skip(noOfRecordToSkip).Take(noOfRecordPerPage).ToList();

                return View("Shop", products);
            }
            switch (id)
            {
                case "lowhigh":
                    products = products.OrderBy(row => row.ProductPrice).ToList();
                    break;
                case "highlow":
                    products = products.OrderByDescending(row => row.ProductPrice).ToList();
                    break;
                case "50-100":
                    products = products.Where(row => row.ProductPrice >= 50 && row.ProductPrice <= 100).ToList();
                    break;
                case "100-150":
                    products = products.Where(row => row.ProductPrice >= 100 && row.ProductPrice <= 150).ToList();
                    break;
                case "over-150":
                    products = products.Where(row => row.ProductPrice >= 150).ToList();
                    break;
            }

            //Pagin
            int NoOfRecordPerPage = 9;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;

            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View("Shop", products);
        }

        public ActionResult RunningShoes(string id, int page = 1)
        {
            NikeDBContext db = new NikeDBContext();
            List<Product> products = db.Products.Where(row => row.ProductGenderId == 1 && row.ApparelId == 1 && row.CategoryId == 4).ToList();
            ViewBag.Heading = "Men's Running Shoes";
            ViewBag.ControlName = "men";
            ViewBag.ActionName = "runningshoes";
            ViewBag.QuantityProDuct = products.Count();
            if (id == null)
            {
                //Pagin
                int noOfRecordPerPage = 9;
                int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(noOfRecordPerPage)));
                int noOfRecordToSkip = (page - 1) * noOfRecordPerPage;

                ViewBag.Page = page;
                ViewBag.NoOfPages = noOfPages;

                products = products.Skip(noOfRecordToSkip).Take(noOfRecordPerPage).ToList();

                return View("Shop", products);
            }
            switch (id)
            {
                case "lowhigh":
                    products = products.OrderBy(row => row.ProductPrice).ToList();
                    break;
                case "highlow":
                    products = products.OrderByDescending(row => row.ProductPrice).ToList();
                    break;
                case "50-100":
                    products = products.Where(row => row.ProductPrice >= 50 && row.ProductPrice <= 100).ToList();
                    break;
                case "100-150":
                    products = products.Where(row => row.ProductPrice >= 100 && row.ProductPrice <= 150).ToList();
                    break;
                case "over-150":
                    products = products.Where(row => row.ProductPrice >= 150).ToList();
                    break;
            }

            //Pagin
            int NoOfRecordPerPage = 9;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;

            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;

            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View("Shop", products);
        }
    }
}