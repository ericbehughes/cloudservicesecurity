﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Administration;

namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetWebConfiguration("MvcWebRole1");
                ConfigurationSection ipSecuritySection = config.GetSection("system.webServer/security/ipSecurity");
                ConfigurationElementCollection ipSecurityCollection = ipSecuritySection.GetCollection();

                ConfigurationElement addElement = ipSecurityCollection.CreateElement("add");
                addElement["ipAddress"] = @"10.10.10.1";
                addElement["allowed"] = true;
                ipSecurityCollection.Add(addElement);


                serverManager.CommitChanges();
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}