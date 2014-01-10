﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Models;
using Helpers;

namespace Website.Controllers
{
    public class ClientController : Controller
    {
        private readonly CreditManagementDBContext _dbContext = new CreditManagementDBContext();
        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddClient()
        {
            return View();
        }

        public ActionResult ClientList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveClientInfo(Client clientToSave)
        {
            var isSuccess = true;
            var message = string.Empty;
            var isNew = clientToSave.ClientId == 0 ? true : false;
            Client createdClient = new Client();

            clientToSave.ActionTime = DateTime.Now;

            if (isNew)
            {
                _dbContext.Clients.Add(clientToSave);
            }
            else
            {
                //Update
            }

            try
            {
                _dbContext.SaveChanges();
                //TODO: get the saved one
            }
            catch (Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }

            return Json(new
            {
                createdClientId = createdClient.ClientId,
                isSuccess = isSuccess,
                message = message,
                html = ""
            }, JsonRequestBehavior.AllowGet);
        }

    }
}