using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CustomerDAO(ApplicationDbContext applicationDbContext) : IDataAccessObject<Customer>
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public void Add(Customer entity) 
        {
            _applicationDbContext.Customers.Add(entity);
            _applicationDbContext.SaveChanges();

        }

        public void Delete(Customer entity)
        {
            _applicationDbContext.Customers.Remove(entity);
            _applicationDbContext.SaveChanges();

        }

        public List<Customer> GetAll()
        {
            return _applicationDbContext.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _applicationDbContext.Customers
                    .Where(c => c.CustomerID == id)
                    .FirstOrDefault();
        }

        public void Update(Customer entity)
        {
            foreach (var customer in _applicationDbContext.Customers)
            {
                if(customer.CustomerID == entity.CustomerID)
                {
                    customer.CustomerFullName = entity.CustomerFullName;
                    customer.Password = entity.Password;
                    customer.Telephone = entity.Telephone;
                    customer.EmailAddress = entity.EmailAddress;
                    customer.CustomerBirthday = entity.CustomerBirthday;
                    customer.CustomerStatus = entity.CustomerStatus;
                    break;
                }
            }
        }
    }
}
