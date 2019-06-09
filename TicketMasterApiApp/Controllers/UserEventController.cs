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
       // [Authorize]
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
    }
}