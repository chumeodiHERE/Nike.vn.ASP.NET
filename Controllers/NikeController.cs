using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nike_vn.Models;

namespace Nike_vn.Controllers
{
    public class NikeController : Controller
    {
        // GET: Nike
        public ActionResult Index()
        {
            return View();
        }
    }
}