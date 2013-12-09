﻿using ClassCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Collections.ObjectModel;


namespace ClassCloud.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //
        // GET: /Student/
        public ActionResult Index()
        {
            string currentUser = User.Identity.GetUserName();
            if (currentUser == "")
            {
                ViewBag.Message = "Would you like to log in";
                return View();
            }
            System.Diagnostics.Debug.WriteLine(currentUser);

            var _CurrUserData = (from _UserData in db.UserDatas
                                 where _UserData.UserName == currentUser
                                 select _UserData);
            UserData CurrUserData = _CurrUserData.FirstOrDefault();
            //return View();
            System.Diagnostics.Debug.WriteLine(CurrUserData.Courses.ToList());
            return View(CurrUserData.Courses.ToList());
        }

        //
        // GET: /Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}