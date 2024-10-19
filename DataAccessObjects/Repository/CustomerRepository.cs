using BusinessObjects;
using DataAccess.DAO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CustomerRepository(CustomerDAO customerDAO) : ICustomerRepository
    {
        private readonly CustomerDAO _customerDAO = customerDAO;

        public Customer FindByEmail(string email)
        {
            return _customerDAO.GetAll()
                .Where(c => c.EmailAddress.ToLower().Equals(email.ToLower()))
                .FirstOrDefault();
        }

        public Customer FindByEmailAndPassword(string email, string password)
        {
            return _customerDAO.GetAll()
                .Where(c => c.EmailAddress.ToLower().Equals(email.ToLower()) && c.Password.Equals(password))
                .FirstOrDefault();
        }

        public List<Customer> FindByName(string name)
        {
            return _customerDAO.GetAll()
                .Where(c => c.CustomerFullName.ToLower().Equals(name.ToLower()))
                .ToList();
        }

        public List<Customer> GetAll()
        {
            return _customerDAO.GetAll();
        }

        public bool IsAdmin(string email, string password)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string adminEmail = configuration["AdminAccount:Email"];
            string adminPassword = configuration["AdminAccount:Password"];

            return email.Equals(adminEmail, StringComparison.OrdinalIgnoreCase) && password.Equals(adminPassword);
        }

        public void Update(Customer customer)
        {
            _customerDAO.Update(customer);
        }

        public void UpdateCustomerStatus(Customer customer, CustomerStatus customerStatus)
        {
            customer.CustomerStatus = customerStatus;
            _customerDAO.Update(customer);
        }
    }
}
