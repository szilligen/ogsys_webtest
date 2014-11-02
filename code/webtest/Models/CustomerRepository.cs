using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webtest.Models;
using webtest.Repositories;

namespace webtest.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomersDbEntities _db = new CustomersDbEntities();

        public IEnumerable<customer> GetAll()
        {
            return _db.customers.ToList();
        }

        public customer GetById(int id)
        {
            return _db.customers.FirstOrDefault(x => x.id == id);
        }

        public void Create(customer obj)
        {
            _db.customers.Add(obj);
            SaveChanges();
        }

        public void Delete(int id)
        {
            customer obj = GetById(id);
            _db.customers.Remove(obj);
            SaveChanges();
        }

        public void SetValuesAndSave(customer original, customer obj)
        {
            _db.customers.Attach(original);
            _db.Entry(original).CurrentValues.SetValues(obj);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}