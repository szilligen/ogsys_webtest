using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtest.Models;
using webtest.Repositories;

namespace webtest.Tests.Models
{
    public class InMemCustomerRepository : ICustomerRepository
    {
        private List<customer> _allCustomers = new List<customer>();
        
        public Exception ExceptionToThrow { get; set; }

        public IEnumerable<customer> GetAll()
        {
            return _allCustomers;
        }

        public customer GetById(int id)
        {
            return _allCustomers.FirstOrDefault(x => x.id == id);
        }

        public void Create(customer obj)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _allCustomers.Add(obj);
        }

        public void Delete(int id)
        {
            _allCustomers.Remove(GetById(id));
        }

        public void SetValuesAndSave(customer original, customer obj)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 1;
        }

        public void SaveChanges(customer objToUpdate)
        {
            foreach (customer obj in _allCustomers)
            {
                if (obj.id == objToUpdate.id)
                {
                    _allCustomers.Remove(obj);
                    _allCustomers.Add(objToUpdate);
                    break;
                }
            }
        }

        public void Add(customer obj)
        {
            _allCustomers.Add(obj);
        }
    }
}
