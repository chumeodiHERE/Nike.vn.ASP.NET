using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nike_vn.Models;
using Nike_vn.ViewModel;
using Nike_vn.Identity;
using Microsoft.AspNet.Identity;
using Nike_vn.Filters;

namespace Nike_vn.Areas.Admin.Controllers
{
    [AuthorFilter]
    public class StatisticsController : Controller
    {
        // GET: Admin/Statistics
        public ActionResult UserList()
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);

            List<AppUser> users = userManager.Users.Where(row => row.UserName != "admin@nike.com" && row.UserName != "manager@nike.com").ToList();
            return View(users);
        }
        public ActionResult OrderList()
        {
            NikeDBContext db = new NikeDBContext();
            List<Order> orders = db.Orders.ToList();
            return View(orders);
        }
    }
}