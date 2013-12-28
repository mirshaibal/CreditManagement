using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBranch()
        {
            return View();
        }

        public ActionResult BranchList()
        {
            return View();
        }

    }
}
