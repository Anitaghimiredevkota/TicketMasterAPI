using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketMasterApiApp.Models;

namespace TicketMasterApiApp.Controllers
{
    public class UserEventController : Controller
    {
        // GET: UserEvent
        [Authorize]
        public ActionResult Index()
        {
            JObject data = TicketMasterApiAppDAL.GetData("https://app.ticketmaster.com/discovery/v2/events.json?countryCode=US&");

            List<Event> favs = new List<Event>();

            foreach(JObject c in data["_embedded"]["events"])
            {
                favs.Add(new Event(c));
            }

            return View(favs);
        }

        [Authorize]
        public ActionResult EventById(string id)
        {
            return View(TicketMasterApiAppDAL.GetEventById(id));
        }

        [Authorize]
        public bool AddToFavorite(string id)
        {
            return UserFavoroiteDBDAL.AddUserFavorite(new Event(TicketMasterApiAppDAL.GetEventById(id)), User.Identity.Name);
        }

        [Authorize]
        public void DeleteFavorite(string id)
        {
            UserFavoroiteDBDAL.DeleteFavorite(id, User.Identity.Name);
        }

        [Authorize]
        public ActionResult GetEventByPrice(double price)
        {

            ViewBag.PriceSearch = "Sorted by Price: $" + price;

            return View("../UserEvent/Index", TicketMasterApiAppDAL.GetEventsByPrice(price));
        }

        //[Authorize]
        //public void UserFavorite()
        //{
        //    IEnumerable<Event> favs = UserFavoroiteDBDAL.GetUserFavorites(User.Identity.Name);
        //    return View(favs);
        //}
    }
}