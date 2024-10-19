using BusinessObjects;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private readonly ICustomerRepository _customerRepository;
        public Login()
        {
            InitializeComponent();
            _customerRepository = DIService.Instance.ServiceProvider.GetService<ICustomerRepository>();
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            //test temp
            //Customer customer = new Customer
            //{
            //    CustomerID = 3,
            //    CustomerFullName = "Tran Thi C",
            //    Password = "123",
            //    Telephone = "0987654321",
            //    EmailAddress = "test@example.com",
            //    CustomerBirthday = new DateOnly(1985, 5, 15),
            //    CustomerStatus = CustomerStatus.Active
            //};


            string email = txtEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is empty, please enter!", "Warning");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format!", "Warning");
                return;
            }

            string password = txtPassword.Password;
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is empty, please enter!", "Warning");
                return;
            }

            if (_customerRepository.IsAdmin(email, password))
            {
                WindowAdmin admin = new WindowAdmin();
                admin.Show();
                Close();
                return;
            }

            Customer customer = _customerRepository.FindByEmailAndPassword(email, password);

            if (customer == null)
            {
                MessageBox.Show("Email or Password wrong!");
                return;
            }
            else
            {
                WindowCustomer customerWindown = new WindowCustomer(customer);
                customerWindown.Show();
                Close();
            }

        }

        private void btn_Login_Admin_Click(object sender, RoutedEventArgs e)
        {
            WindowAdmin admin = new WindowAdmin();
            admin.Show();
            Close();
            return;
        }
    }
}
