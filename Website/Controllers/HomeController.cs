using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            if (Session["User"] != null)
            {
                ViewBag.LoggedInUserNamer = (Session["User"] as User).Name;
            }

            //Show the loggedin user name
            ViewBag.LoggedInUserName = (Session["User"] as User).Name;

            return View("HomePage");
        }       

    }
}
