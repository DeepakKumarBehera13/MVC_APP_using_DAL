﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapplicationDemo.Models;
using MVCapplicationDemo.DAL;

namespace MVCapplicationDemo.Controllers
{
    public class CustomerController : Controller
    {   
        [HttpGet]
        public ActionResult InsertCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCustomer(Models.Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid)     
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);    
                TempData["result1"] = result;
                ModelState.Clear();    
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllCustomerDetails()
        {
            Models.Customer objCustomer = new Models.Customer();
            DataAccessLayer objDB = new DataAccessLayer();     
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }
        [HttpGet]
        public ActionResult Details(string ID)
        {   
            Models.Customer objCustomer = new Models.Customer();
            DataAccessLayer objDB = new DataAccessLayer();    
            return View(objDB.SelectDatabyID(ID));
        }
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Models.Customer objCustomer = new Models.Customer();
            DataAccessLayer objDB = new DataAccessLayer();   
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Models.Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid)    
            {
                DataAccessLayer objDB = new DataAccessLayer();     
                string result = objDB.UpdateData(objCustomer);    
                TempData["result2"] = result;
                ModelState.Clear();        
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear();     
            return RedirectToAction("ShowAllCustomerDetails");
        }
    }
}