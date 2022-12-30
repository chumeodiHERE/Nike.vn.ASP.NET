using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nike_vn.Models;
using Nike_vn.ViewModel;
using Nike_vn.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Nike_vn.Filters;

namespace Nike_vn.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpVM sgvm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passHash = Crypto.HashPassword(sgvm.Password);
                var user = new AppUser()
                {
                    Email = sgvm.UserName,
                    UserName = sgvm.UserName,
                    PasswordHash = passHash,
                    FristName = sgvm.FristName,
                    LastName = sgvm.LastName,
                    BirthDay = sgvm.BirthDay,
                    Country = sgvm.Country,
                    Gender = sgvm.Gender
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Nike");
            }
            else
            {
                ModelState.AddModelError("Error", "Invalid Data");
                return View();
            }
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInVM sgivm)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            if (sgivm.UserName == null || sgivm.Password == null)
            {
                return View();
            }
            var user = userManager.Find(sgivm.UserName, sgivm.Password);

            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin"});
                }
                return RedirectToAction("Index", "Nike");
            } else
            {
                ModelState.AddModelError("ErrorText", "Invalid Username or Password");
                return View();
            }
        }

        public ActionResult SignOut()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Nike");
        }

        [AuthenFilter]
        public ActionResult MyProfile()
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(User.Identity.GetUserId());
            return View(user);
        }

        [AuthenFilter]
        public ActionResult Cart()
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(User.Identity.GetUserId());

            NikeDBContext db = new NikeDBContext();
            List<Cart> carts = db.Carts.Where(row => row.Id == user.Id).ToList();
            ViewBag.TotalMoney = 0;
            ViewBag.Price = 0;
            ViewBag.userId = user.Id;
            return View(carts);
        }

        [AuthenFilter]
        [HttpPost]
        public ActionResult CartRemove(Store store)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(User.Identity.GetUserId());

            NikeDBContext db = new NikeDBContext();
            Cart cart = db.Carts.Where(row => row.Id == user.Id && row.ProductId == store.ProductId && row.ProductSizeId == store.ProductSizeId).FirstOrDefault();
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Cart", "Account");
        }

        [AuthenFilter]
        [HttpPost]
        public ActionResult CartAdd(Store store)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(User.Identity.GetUserId());

            NikeDBContext db = new NikeDBContext();

            Cart cart = new Cart();
            cart.Id = user.Id;
            cart.ProductId = store.ProductId;
            cart.ProductSizeId = store.ProductSizeId;
            cart.Quantity = 1;

            Cart cartExist = db.Carts.Where(row => row.Id == user.Id && row.ProductId == store.ProductId && row.ProductSizeId == store.ProductSizeId).FirstOrDefault();

            if (cartExist == null)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                
            } else
            {
                cartExist.Id = cart.Id;
                cartExist.ProductId = cart.ProductId;
                cartExist.ProductSizeId = cart.ProductSizeId;
                cartExist.Quantity = cartExist.Quantity + 1;
                db.SaveChanges();
            }
            return RedirectToAction("Cart", "Account");
        }

        [AuthenFilter]
        public ActionResult CheckOut()
        {
            return View();
        }

        [AuthenFilter]
        [HttpPost]
        public ActionResult CheckOut(Order order)
        {
            NikeDBContext db = new NikeDBContext();
            //Order ord = new Order();
            //ord.UserId = order.UserId;
            //ord.Total = order.Total;
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("CheckOut", "Account");
        }
    }
}