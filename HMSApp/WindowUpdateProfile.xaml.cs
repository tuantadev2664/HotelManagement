using BusinessObjects;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for WindowUpdateProfile.xaml
    /// </summary>
    public partial class WindowUpdateProfile : Window
    {
        private readonly ICustomerRepository _customerRepository;
        private Customer customer;
        private P_CustomerProfile customerProfile;

        public WindowUpdateProfile(Customer customer, P_CustomerProfile customerProfile)
        {
            InitializeComponent();

            this.customer = customer;
            this.customerProfile = customerProfile;
            tb_FullName.Text = customer.CustomerFullName;
            tb_Telephone.Text = customer.Telephone;
            tb_EmailAddress.Text = customer.EmailAddress;
            dp_Birthday.Text = customer.CustomerBirthday.ToString();
            _customerRepository = DIService.Instance.ServiceProvider.GetService<ICustomerRepository>();
        }

        public void btn_cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void btn_submit(object sender, RoutedEventArgs e)
        {
            if (!IsAllTextboxEntered())
            {
                MessageBox.Show("Please input all fields!");
                return;
            }

            string fullName = tb_FullName.Text.Trim();
            string telephone = tb_Telephone.Text.Trim();
            string email = tb_EmailAddress.Text.Trim();

            var customerFindByEmail = _customerRepository.FindByEmail(email);
            if (customerFindByEmail != null && customerFindByEmail.CustomerID != customer.CustomerID)
            {
                MessageBox.Show(email + " already taken, choose another!");
                return;
            }

            DateTime? birthday = dp_Birthday.SelectedDate;

            if (fullName.Length < 3 || fullName.Length > 50)
            {
                MessageBox.Show("Full Name must be between 3 and 50 characters.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(telephone, @"^\d{10,15}$"))
            {
                MessageBox.Show("Telephone must be a number between 10 and 15 digits.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email address.");
                return;
            }

            if (!birthday.HasValue)
            {
                MessageBox.Show("Please select a valid birthday.");
                return;
            }

            int age = CalculateAge(birthday.Value);
            if (age < 18)
            {
                MessageBox.Show("Customer must be at least 18 years old.");
                return;
            }


            customer.CustomerFullName = fullName;
            customer.Telephone = telephone;
            customer.EmailAddress = email;
            customer.CustomerBirthday = DateOnly.FromDateTime(birthday.Value);

            _customerRepository.Update(customer);

            MessageBox.Show("Profile updated successfully!");
            customerProfile.UpdateVisual();
            this.Close();
        }

        private bool IsAllTextboxEntered()
        {
            if (string.IsNullOrEmpty(tb_FullName.Text)) return false;
            if (string.IsNullOrEmpty(tb_Telephone.Text)) return false;
            if (string.IsNullOrEmpty(tb_EmailAddress.Text)) return false;
            if (string.IsNullOrEmpty(dp_Birthday.Text)) return false;
            return true;
        }

        private int CalculateAge(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;

            if (birthday.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
