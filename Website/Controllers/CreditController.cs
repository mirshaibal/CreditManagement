using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Models;
using Helpers;

namespace Website.Controllers
{
    public class CreditController : Controller
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
            //Show the loggedin user name
            ViewBag.LoggedInUserName = (Session["User"] as User).Name;

            ViewBag.LoggedInUserId = (Session["User"] as User).UserId;

            return View();
        }

        public ActionResult CreditDetails()
        {
            //Show the loggedin user name
            ViewBag.LoggedInUserName = (Session["User"] as User).Name;

            return View("CreditDetails");
        }

        public ActionResult CreditList()
        {
            var user = Session["User"] as User;

            if (user == null)
            {
                Response.Redirect("/Home/Index");
            }

            //Show the loggedin user name
            ViewBag.LoggedInUserName = (Session["User"] as User).Name;

            return View("CreditList");
        }

        public ActionResult CreditFiles()
        {
            //Show the loggedin user name
            ViewBag.LoggedInUserName = (Session["User"] as User).Name;

            return View("CreditFiles");
        }

        [HttpPost]
        public JsonResult SaveCreditInfo(CreditInfo creditInfo)
        {
            var isSuccess = true;
            var message = string.Empty;
            var isNew = creditInfo.CreditInfoId == 0 ? true : false;
            CreditInfo createdCreditInfo = new CreditInfo();

            creditInfo.CreateTime = DateTime.Now;

            if (isNew)
            {
                _dbContext.CreditInfoes.Add(creditInfo);
                int loggedInUserId = (Session["User"] as User).UserId;

                // Credit flow
                if (creditInfo.Status > 0)
                {
                    CreditFlow creditFlow = new CreditFlow();
                    creditFlow.AssignFromUserId = loggedInUserId;
                    creditFlow.AssignToUserId = creditInfo.AssignUserId;
                    creditFlow.CreditInfoId = creditInfo.CreditInfoId;
                    creditFlow.ActionTime = DateTime.Now;
                    _dbContext.CreditFlows.Add(creditFlow);
                }
            }
            else
            {
                CreditInfo creditInfoReturn = GetCreditInfo(creditInfo.CreditInfoId).Data as CreditInfo;
                creditInfoReturn.BranchId = creditInfo.BranchId;
                creditInfoReturn.ClientId = creditInfo.ClientId;
                creditInfoReturn.CreatedUserId = creditInfo.CreatedUserId;
                creditInfoReturn.Info = creditInfo.Info;
                creditInfoReturn.Status = creditInfo.Status;
            }

            try
            {
                _dbContext.SaveChanges();

                createdCreditInfo = (from ci in _dbContext.CreditInfoes
                                  orderby ci.CreateTime descending
                                  select ci).FirstOrDefault();

                ViewBag.ProposalId = createdCreditInfo.CreditInfoId;
            }
            catch (Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }

            //Response.Redirect("/Credit/AddCredit?CreditId=" + createdCreditInfo.CreditInfoId);

            return Json(new
            {
                createdCreditInfoId = createdCreditInfo.CreditInfoId,
                isSuccess = isSuccess,
                message = message,
                html = ""
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveCreditFlow(CreditFlow creditFlow, int status)
        {
            var isSuccess = true;
            var message = string.Empty;

            int loggedInUserId = (Session["User"] as User).UserId;

            creditFlow.AssignFromUserId = loggedInUserId;
            creditFlow.ActionTime = DateTime.Now;
            creditFlow.IsLatestComment = true;

            // Change the statis
            //if (status == 1)
            //{
                CreditInfo ci = (from c in _dbContext.CreditInfoes where c.CreditInfoId == creditFlow.CreditInfoId select c).FirstOrDefault();
                ci.Status = status;
            //}
            
            try
            {
                // Set IsLatestComment = false for existing all recores
                var records = _dbContext.CreditFlows.Where(x => x.CreditInfoId == creditFlow.CreditInfoId).ToList();
                records.ForEach(r => r.IsLatestComment = false);

                // Update record
                CreditInfo creditInfo = (from c in _dbContext.CreditInfoes
                                  where c.CreditInfoId == creditFlow.CreditInfoId
                                  select c).FirstOrDefault();
                creditInfo.AssignUserId = creditFlow.AssignToUserId;

                // Add new records
                _dbContext.CreditFlows.Add(creditFlow);

                // Save changes
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }

            return Json(new
            {
                isSuccess = isSuccess,
                message = message,
                html = ""
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveRelationshipSummary(RelationshipSummary rs)
        {
            var isSuccess = true;
            var message = string.Empty;
            int loggedInUserId = (Session["User"] as User).UserId;

            try
            {
                _dbContext.RelationshipSummaries.Add(rs);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }

            return Json(new
            {
                isSuccess = isSuccess,
                message = message,
                html = ""
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRelationshipSummaryList(int creditId)
        {
            //int creditId = int.Parse(Request.QueryString.Get("CreditId").ToString());

            var list = (from f in _dbContext.RelationshipSummaries
                        orderby f.FacilityNature
                        where f.CreditInfoId == creditId
                        select f).ToList();

            return Json(new
            {
                html = this.RenderPartialView("_RelationshipSummaryList", list)
            }, JsonRequestBehavior.AllowGet);
        }
    
        public JsonResult GetCreditInfo(int id)
        {
            var creditInfo = (from c in _dbContext.CreditInfoes
                                where c.CreditInfoId == id
                                select c).FirstOrDefault();

            List<CreditFlow> creditFlowList = (from cf in _dbContext.CreditFlows
                                  where cf.CreditInfoId == id
                                  orderby cf.ActionTime descending
                                  select cf).ToList();

            creditInfo.CreditFlows = new List<CreditFlow>();
            creditInfo.CreditFlows = creditFlowList;

            return Json(new
            {
                html = this.RenderPartialView("_CreditInfoDetails", creditInfo)
            }, JsonRequestBehavior.AllowGet);      
        }

        public JsonResult GetCreditBasicInfo(int creditId)
        {
            var creditInfo = (from c in _dbContext.CreditInfoes
                              where c.CreditInfoId == creditId
                              select new { Subject = c.Subject, BranchId = c.BranchId, ClientId = c.ClientId,
                              SubjectDetails = c.SubjectDetails, BorrowerName = c.BorrowerName,
                              ApplicationDate = c.ApplicationDate, BranchProposalDate = c.BranchProposalDate,
                              BranchRef = c.BranchRef, ProposedFacility = c.ProposedFacility}).FirstOrDefault();

            return Json(creditInfo, JsonRequestBehavior.AllowGet);        
        }

        public JsonResult GetBranchList()
        {
            var branchList = (from b in _dbContext.Branches
                                orderby b.Name
                                select new { key = b.BranchId, value = b.Name }).ToList();

            return Json(branchList);
        }

        public JsonResult GetClientList(int branchId)
        {
            var clientList = (from c in _dbContext.Clients
                              orderby c.Name
                              where c.BranchId == branchId
                              select new { key = c.ClientId, value = c.Name }).ToList();

            return Json(clientList);
        }

        public JsonResult GetCreditFileList(int creditId)
        {
            //int creditId = int.Parse(Request.QueryString.Get("CreditId").ToString());

            var list = (from f in _dbContext.CreditFiles
                              orderby f.Title
                              where f.CreditInfoId == creditId
                              select f).ToList();            

            return Json(new
            {
                html = this.RenderPartialView("_CreditFileList", list)
            }, JsonRequestBehavior.AllowGet);            
        }

        public JsonResult GetCreditInfoList()
        {
            var user = Session["User"] as User;

            if (user == null)
            {
                Response.Redirect("/Home/Index");
            }

            var list = new List<CreditInfo>();

            if (user.Role.Name.ToLower() == "md" || user.Role.Name.ToLower() == "board")
            {
                list = (from c in _dbContext.CreditInfoes
                        select c).ToList();
            }
            else
            {
                list = (from c in _dbContext.CreditInfoes
                        where c.AssignUserId == user.UserId //|| c.CreatedUserId == user.UserId
                        select c).ToList();
            }

            

            return Json(new
            {
                html = this.RenderPartialView("_CreditInfoList", list)
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPendingReviewList()
        {
            var user = Session["User"] as User;

            if (user == null)
            {
                Response.Redirect("/Hope/Index");
            }

            var list = new List<CreditFlow>();

            list = (from c in _dbContext.CreditFlows
                        where c.AssignToUserId == user.UserId && c.IsLatestComment == true
                        orderby c.ActionTime descending
                        select c).ToList();
            
            return Json(new
            {
                html = this.RenderPartialView("_CreditInfoPendingList", list)
            }, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetCreditInfoList(int userId)
        {
            var list = (from c in _dbContext.CreditInfoes
                        where c.AssignUserId == userId
                        select c).ToList();            

            return Json(new
            {
                html = this.RenderPartialView("_CreditInfoList", list)
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCreditProposalCountByUser(FormCollection collection)
        {
            var user = Session["User"] as User;
            if (user == null)
            {
                Response.Redirect("/Home/Index");
            }
           
            var myPendingCount = (from c in _dbContext.CreditInfoes
                        where c.AssignUserId == user.UserId
                        select c).Count();

            var allCount = (from c in _dbContext.CreditInfoes
                           select c).Count();

            return Json(new
            {
                myPendingCount = myPendingCount,
                allCount = allCount
            }, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void UploadFile(FormCollection collection)
        {
            //int creditId = int.Parse(Request.QueryString.Get("creditId").ToString());
            string title = collection.Get("ddlFileTitle");
            int creditId = int.Parse(collection.Get("lblCreditId"));
            
            if (Request.Files["file"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
                string fileName = title + "_" + creditId.ToString() + extension;

                string filePath = string.Format("{0}/{1}", Server.MapPath("~/CreditFiles"), fileName);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                Request.Files["file"].SaveAs(filePath);

                // Save to DB
                CreditFile cf = new CreditFile();
                cf.CreditInfoId = creditId;
                cf.FilePath = string.Format("/{0}/{1}", "CreditFiles", fileName);
                cf.Title = title;
                cf.ActionTime = DateTime.Now;
                
                _dbContext.CreditFiles.Add(cf);
                _dbContext.SaveChanges();

            }

            Response.Redirect("/Credit/CreditFiles?creditId=" + creditId);
        }

        public JsonResult DeleteFile()
        {
            return null;
        }

        /****** Start: Facility Details Actions ******/
        public JsonResult GetNatureOfFacilities()
        {
            var natureOfFacilities = new Dictionary<int, string>
            {
                {1, "Term Loan"},
                {2, "CC (Hypo)"},
                {3, "SOD(Gen)"},
                {4, "SOD(FO)"},
                {5, "SOD(WO)"},
                {6, "Revolving L/C, cash, Deferred, BB, EDF"},
                {7, "ABP"},
                {8, "PAD"},
                {9, "EDF"},
                {10, "LTR (subsequent)"},
                {11, "Case to Case LC"},
                {12, "LTR"},
                {13, "B/G"}
            };

            return Json(natureOfFacilities.ToList());
        }

        [HttpPost]
        public JsonResult SaveFacilityDetail(FacilityDetail facilityDetail)
        {
            var isSuccess = true;
            var message = string.Empty;
            var isNew = true;
            facilityDetail.CreateTime = DateTime.Now;

            if (isNew)
            {
                //facilityDetail.FacilityDetailId = ((int)TempData["TotalFacilityDetailRecords"]) + 1;
                _dbContext.FacilityDetails.Add(facilityDetail);
            }
            else
            {
                //TODO
                //FacilityDetail facilityDetailReturn = GetFacilityDetail(facilityDetail.FacilityDetailId).Data as FacilityDetail;
                //facilityDetailReturn.NatureOfFacility = facilityDetail.NatureOfFacility;
                //facilityDetailReturn.EOL = facilityDetail.EOL;
                //TODO
            }

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }

            return Json(new
            {
                isSuccess = isSuccess,
                message = message,
                html = ""
            }, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetFacilityDetailList(int creditInfoId)
        {
            var facilityDetailList = (from c in _dbContext.FacilityDetails where c.CreditInfoId == creditInfoId select c).ToList();
            TempData["TotalFacilityDetailRecords"] = facilityDetailList.Count;
            ViewBag.NatureOfFacility = GetNatureOfFacilities();

            return Json(new
            {
                html = this.RenderPartialView("_FacilityDetails", facilityDetailList)
            }, JsonRequestBehavior.AllowGet);
        }
        /****** End: Facility Details Actions ******/

        /*Start: CIB Status*/
        [HttpPost]
        public JsonResult SaveCIBStatus(CIBStatu cibStatu)
        {
            var isSuccess = true;
            var message = string.Empty;
            var isNew = cibStatu.CIBStatusId == 0;
            cibStatu.ReportDate = DateTime.Now;

            if (isNew)
            {
                //cibStatu.CIBStatusId = ((int)TempData["TotalCIBStatusRecords"]) + 1;
                _dbContext.CIBStatus.Add(cibStatu);
            }
            else
            {
                //TODO
                //FacilityDetail facilityDetailReturn = GetFacilityDetail(facilityDetail.FacilityDetailId).Data as FacilityDetail;
                //facilityDetailReturn.NatureOfFacility = facilityDetail.NatureOfFacility;
                //facilityDetailReturn.EOL = facilityDetail.EOL;
                //TODO
            }

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }

            return Json(new
            {
                isSuccess = isSuccess,
                message = message,
                html = ""
            }, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetCIBStatusList()
        {
            var cibStatusList = (from c in _dbContext.CIBStatus select c).ToList();
            TempData["TotalCIBStatusRecords"] = cibStatusList.Count;

            return Json(new
            {
                html = this.RenderPartialView("_CIBStatus", cibStatusList)
            }, JsonRequestBehavior.AllowGet);
        }
        /*End: CIB Status*/
    }
}
