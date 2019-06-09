﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicketMasterApiApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //TicketMasterApiApp.Models.TicketMasterApiAppDAL.GetData("");
            //TicketMasterApiApp.Models.TicketMasterApiAppDAL.GetEventById("");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}