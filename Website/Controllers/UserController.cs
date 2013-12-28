using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Models;
using Helpers;

namespace Website.Controllers
{
    public class UserController : Controller
    {
        private readonly CreditManagementDBContext _dbContext = new CreditManagementDBContext();

        //
        // GET: /Credit/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCredit()
        {
            return View();
        }

        public JsonResult GetUserList()
        {
            var userList = (from u in _dbContext.Users
                                orderby u.Name
                                select new { key = u.UserId, value = u.Name }).ToList();

            return Json(userList);
        }

        public JsonResult Login(string username, string password)
        {
            var user = (from u in _dbContext.Users
                            where u.UserName == username && u.Password == password
                            select u).FirstOrDefault();

            if (user != null)
            {                
                Session["User"] = user;
            }

            //Show the loggedin user name
            ViewBag.LoggedInUserName = (Session["User"] as User).Name;

            return Json(user.Name);
        }

        public void Logout()
        {
            Response.Redirect("/Home/Index");

            /*
             * @if (Session["User"] != null)
                        {
                            if ((Session["User"] as DataObjects.Models.User).Role.Name.ToLower() == "md" || (Session["User"] as DataObjects.Models.User).Role.Name.ToLower() == "board")
                            {
                                @*<div>@((DataObjects.Models.User)Session["User"]).Name</div>*@
                                <div>@ViewBag.LoggedInUserNamer</div>
                            }
                        }
             * */
        }

    }
}
