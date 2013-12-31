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
            var user = Session["User"] as User;

            if (user.Role.Name.ToLower() == "executive")
            {
                var userList1 = (from u in _dbContext.Users
                                where u.Role.Name.ToLower() == "branch manager" && u.BranchId == user.BranchId
                                orderby u.Name
                                select new { key = u.UserId, value = u.Name }).ToList();

                return Json(userList1);
            }
            else if (user.Role.Name.ToLower() == "branch manager")
            {
                var userList2 = (from u in _dbContext.Users
                                where u.Role.Name.ToLower() == "credit head"
                                || (u.Role.Name.ToLower() == "executive" && u.BranchId == user.BranchId)
                                orderby u.Name
                                select new { key = u.UserId, value = u.Name }).ToList();

                return Json(userList2);
            }
            else if (user.Role.Name.ToLower() == "credit head" || user.Role.Name.ToLower() == "md" 
                || user.Role.Name.ToLower() == "md"
                || user.Role.Name.ToLower() == "mcc"
                || user.Role.Name.ToLower() == "board")
            {

                int creditInfoId = 24; // int.Parse(Request.QueryString.Get("creditId"));
                var creditInfo = (from c in _dbContext.CreditInfoes
                                  where c.CreditInfoId == creditInfoId
                                  select c).FirstOrDefault();

                var userList3 = (from u in _dbContext.Users
                                 where u.Role.Name.ToLower() == "credit head"
                                 || u.Role.Name.ToLower() == "md"
                                 || u.Role.Name.ToLower() == "mcc"
                                 || u.Role.Name.ToLower() == "board"
                                 || (u.Role.Name.ToLower() == "branch manager" && u.BranchId == creditInfo.BranchId)
                                 orderby u.Name
                                 select new { key = u.UserId, value = u.Name }).ToList();

                return Json(userList3);
            }

            //var userList = (from u in _dbContext.Users
            //                    orderby u.Name
            //                    select new { key = u.UserId, value = u.Name }).ToList();

            return Json(null);
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
