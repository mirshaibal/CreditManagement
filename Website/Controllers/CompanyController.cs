using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Models;
using Helpers;

namespace Website.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CreditManagementDBContext _dbContext = new CreditManagementDBContext();
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

        [HttpPost]
        public JsonResult SaveBranchInfo(Branch branchToSave)
        {
            var isSuccess = true;
            var message = string.Empty;
            var isNew = branchToSave.BranchId == 0 ? true : false;
            Branch createdBranch = new Branch();

            branchToSave.ActionTime = DateTime.Now;

            if (isNew)
            {
                _dbContext.Branches.Add(branchToSave);                
            }
            else
            {
                //CreditInfo creditInfoReturn = GetCreditInfo(branch.CreditInfoId).Data as CreditInfo;
                //creditInfoReturn.BranchId = branch.BranchId;
                //creditInfoReturn.ClientId = branch.ClientId;
                //creditInfoReturn.CreatedUserId = branch.CreatedUserId;
                //creditInfoReturn.Info = branch.Info;
                //creditInfoReturn.Status = branch.Status;
            }

            try
            {
                _dbContext.SaveChanges();

                //createdBranch = (from branch in _dbContext.Branches
                //                     orderby branch.CreateTime descending
                //                     select branch).FirstOrDefault();

            }
            catch (Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }

            return Json(new
            {
                createdBranchId = createdBranch.BranchId,
                isSuccess = isSuccess,
                message = message,
                html = ""
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
