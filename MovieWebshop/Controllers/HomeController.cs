using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopLexicon.Models;

namespace WebshopLexicon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Day = DateTime.Now.ToLongDateString();
            ViewBag.Time = DateTime.Now.ToShortTimeString();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Day = DateTime.Now.ToLongDateString();
            ViewBag.Time = DateTime.Now.ToShortTimeString();
            ViewBag.Message = "About us";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Day = DateTime.Now.ToLongDateString();
            ViewBag.Time = DateTime.Now.ToShortTimeString();
            ViewBag.Message = "Contact Us";
            return View();
        }

        public ActionResult ShoppingCart()
        {
            ViewBag.Day = DateTime.Now.ToLongDateString();
            ViewBag.Time = DateTime.Now.ToShortTimeString();
            var cookie = Request.Cookies["userShopping"];
            ViewBag.MovieName = (cookie).Values["Movie Name"];
            ViewBag.Price = (cookie).Values["Price"];
            return View();
        }
        public ActionResult Checkout()
        {
            ViewBag.Day = DateTime.Now.ToLongDateString();
            ViewBag.Time = DateTime.Now.ToShortTimeString();
            var cookie = Request.Cookies["userShopping"];
            ViewBag.Price = (cookie).Values["Price"];
            return View();
        }

    }
}