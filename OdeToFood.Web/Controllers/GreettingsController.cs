﻿using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreettingsController : Controller
    {
        // GET: Greettings
        public ActionResult Index(string name)
        {
            var model = new GreetingsViewModel();
            model.Message = ConfigurationManager.AppSettings["message"];
            model.Name = name ?? "no name";

            return View(model);
        }
    }
}