using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtest.Models;

namespace webtest.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<customer> GetAll();
        customer GetById(int id);
        void Create(customer obj);
        void Delete(int id);
        void SetValuesAndSave(customer original, customer obj);
        int SaveChanges();
    }
}
