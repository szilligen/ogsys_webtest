using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;

namespace webtest.Controllers
{
    public class NoteController : Controller
    {
        CustomersDbEntities _db = new CustomersDbEntities();

        public NoteController()
        {
            _db = new CustomersDbEntities();
        }

        //
        // GET: /Note/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Note/Create

        public ActionResult Create(int customerid)
        {
            var model = new note { customerid = customerid };
            return View(model);
        }

        //
        // POST: /Note/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, note model)
        {
            try
            {
                model.createdbyuser = User.UserId();
                customer parent = _db.customers.Find(model.customerid);
                parent.notes.Add(model);
                //_db.notes.Add(model);
                _db.SaveChanges();

                return RedirectToAction("../Customer/Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Note/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Note/Edit/5

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
        // GET: /Note/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Note/Delete/5

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
