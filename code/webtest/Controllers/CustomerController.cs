using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using webtest.Models;
using webtest.Repositories;

namespace webtest.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepository _repository;

        public CustomerController() :this(new CustomerRepository()) {}

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            ViewData.Model = _repository.GetAll();
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

                _repository.Create(model);

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
            customer model = _repository.GetById(id);
            ViewData.Model = model;
            return View();
        }

        public FileResult GetProfileImage(int id)
        {
            customer model = _repository.GetById(id);
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

                customer original = _repository.GetById(id);
                _repository.SetValuesAndSave(original, model);
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
                _repository.Delete(id);
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
            ViewData.Model = _repository.GetById(id);
            return View();
        }
    }
}
