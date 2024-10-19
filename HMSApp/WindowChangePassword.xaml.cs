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
    /// Interaction logic for WindowChangePassword.xaml
    /// </summary>
    public partial class WindowChangePassword : Window
    {
        private Customer customer;
        private readonly ICustomerRepository _customerRepository;

        public WindowChangePassword(Customer customer)
        {
            InitializeComponent();

            this.customer = customer;
            _customerRepository = DIService.Instance.ServiceProvider.GetService<ICustomerRepository>();
        }

        public void btn_submit(object sender, RoutedEventArgs e)
        {
            string oldPass = pbOldPassword.Password;
            string newPass = pbNewPassword.Password;
            string confirmNewPass = pbReNewPassword.Password;

            if (newPass.Equals(oldPass))
            {
                MessageBox.Show("New password equal Old password, please input new password!");
            }
            else if (!newPass.Equals(confirmNewPass))
            {
                MessageBox.Show("Confirm password invalid, please input again!");
            }
            else
            {
                customer.Password = newPass;
                _customerRepository.Update(customer);
                MessageBox.Show("Update Password Successfully!");
                Close();
            }
        }

        public void btn_cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
