using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtest.Models;
using webtest.Repositories;

namespace webtest.Controllers
{
    public class NoteController : Controller
    {
        ICustomerRepository _repository;

        public NoteController() :this(new CustomerRepository()){}

        public NoteController(ICustomerRepository repository)
        {
            _repository = repository;
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
                customer parent = _repository.GetById(model.customerid);
                parent.notes.Add(model);
                _repository.SaveChanges();

                return RedirectToAction("../Customer/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
