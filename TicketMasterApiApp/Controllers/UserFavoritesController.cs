using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketMasterApiApp.Models;

namespace TicketMasterApiApp.Controllers
{
    public class UserFavoritesController : Controller
    {
        private AllDBContext db = new AllDBContext();

        // GET: UserFavorites
        public ActionResult Index()
        {
            List<UserFavorite> userFavorite = db.UserFavorites.Where(e => e.UserId == User.Identity.Name)
                .Include("Event")
                .ToList();

            return View(userFavorite);
        }

        // GET: UserFavorites/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFavorite userFavorite = db.UserFavorites.Find(id);
            if (userFavorite == null)
            {
                return HttpNotFound();
            }
            return View(userFavorite);
        }

        // GET: UserFavorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserFavorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,EventId")] UserFavorite userFavorite)
        {
            if (ModelState.IsValid)
            {
                db.UserFavorites.Add(userFavorite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userFavorite);
        }

        // GET: UserFavorites/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFavorite userFavorite = db.UserFavorites.Find(id);
            if (userFavorite == null)
            {
                return HttpNotFound();
            }
            return View(userFavorite);
        }

        // POST: UserFavorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,EventId")] UserFavorite userFavorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userFavorite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userFavorite);
        }

        // GET: UserFavorites/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFavorite userFavorite = db.UserFavorites.Find(id);
            if (userFavorite == null)
            {
                return HttpNotFound();
            }
            return View(userFavorite);
        }

        // POST: UserFavorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserFavorite userFavorite = db.UserFavorites.Find(id);
            db.UserFavorites.Remove(userFavorite);
            db.SaveChanges();
            return RedirectToAction("Index");
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
