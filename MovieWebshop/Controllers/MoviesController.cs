using MovieWebshop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebshopLexicon.Models;

namespace WebshopLexicon.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        
        public ViewResult Index(string searchBy, string search)
        {
            if (searchBy == "Director")
            {
                return View(db.Movies.Where(x=> x.Director==search ||search==null).ToList());
            }
            else
            {
                return View(db.Movies.Where(x => x.MovieName.StartsWith(search) || search == null).ToList());
            }
            
            ViewBag.Day = DateTime.Now.ToLongDateString();
            ViewBag.Time = DateTime.Now.ToShortTimeString();
            return View(db.Movies.ToList());
        }
        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,MovieName,Price,Director,ReleaseYear,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }


        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(string input, int id)
        {
            Movie movie = new Movie();

            HttpCookie cookie1 = new HttpCookie("userShopping");

            var movieName1 = from r in db.Movies
                             where r.MovieID == id
                             select r.MovieName;
            cookie1.Values["Movie Name"] = movieName1.FirstOrDefault();

            var movieDirector1 = from a in db.Movies
                                 where a.MovieID == id
                                 select a.Director;
            cookie1.Values["Director"] = movieDirector1.FirstOrDefault();

            var moviePrice1 = from a in db.Movies
                              where a.MovieID == id
                              select a.Price;
            cookie1.Values["Price"] = moviePrice1.FirstOrDefault();

            var releaseYear1 = from b in db.Movies
                               where b.MovieID == id
                               select b.ReleaseYear;
            cookie1.Values["Release Year"] = releaseYear1.FirstOrDefault();
            Response.Cookies.Add(cookie1);
            cookie1.Expires = DateTime.Now.AddMinutes(15);
            return RedirectToAction("ShoppingCart", "Home");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}