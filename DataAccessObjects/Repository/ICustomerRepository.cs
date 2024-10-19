using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();
        public List<Customer> FindByName(string name);

        public void UpdateCustomerStatus(Customer customer, CustomerStatus customerStatus);

        public void Update(Customer customer);

        public Customer FindByEmailAndPassword(string email, string password);

        public Customer FindByEmail(string email);

        public bool IsAdmin(string email, string password);
    }
}
