using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using webtest.Models;

namespace webtest.Controllers
{
    public class CustomerController : Controller
    {
        CustomersDbEntities _db = new CustomersDbEntities();

        public CustomerController()
        {
            _db = new CustomersDbEntities();
        }

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            ViewData.Model = _db.customers.ToList();
            return View();
        }

        public string GetUserDisplayName(string userid)
        {
            AccountController acctCtrlr = new AccountController();
            ApplicationUser user = acctCtrlr.UserManager.FindById(userid);
            if (String.IsNullOrEmpty(user.Fname) || String.IsNullOrEmpty(user.Lname))
            {
                return user.UserName;
            }
            else
            {
                return String.Format("{0} {1}", user.Fname, user.Lname);
            }
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, customer model)
        {
            try
            {
                WebImage img = WebImage.GetImageFromRequest();
                if (img != null)
                {
                    model.picture = img.GetBytes();
                }

                _db.customers.Add(model);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id)
        {
            customer model = _db.customers.Where(x => x.id == id).SingleOrDefault();
            ViewData.Model = model;
            return View();
        }

        public FileResult GetProfileImage(int id)
        {
            customer model = _db.customers.Where(x => x.id == id).SingleOrDefault();
            if (model.picture != null)
            {
                WebImage image = new WebImage(model.picture);
                return File(image.GetBytes(), "image/" + image.ImageFormat, image.FileName);
            }
            return null;
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, customer model)
        {
            try
            {
                WebImage img = WebImage.GetImageFromRequest();
                if (img != null)
                {
                    model.picture = img.GetBytes();
                }

                customer original = _db.customers.Single(c => c.id == id);
                _db.customers.Attach(original);
                _db.Entry(original).CurrentValues.SetValues(model);
                _db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                customer model = _db.customers.Where(x => x.id == id).SingleOrDefault();
                _db.customers.Remove(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/AddNote

        public ActionResult AddNote(int id)
        {
            ViewData.Model = _db.customers.Where(x => x.id == id).SingleOrDefault();
            return View();
        }
    }
}
