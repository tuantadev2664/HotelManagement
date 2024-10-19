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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for P_CustomerManagement.xaml
    /// </summary>
    public partial class P_CustomerManagement : Page
    {
        private Customer currentSelect;
        private readonly ICustomerRepository customerRepository;

        public P_CustomerManagement()
        {
            InitializeComponent();

            customerRepository = DIService.Instance.ServiceProvider.GetService<ICustomerRepository>();

            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            dataGrid.ItemsSource = customerRepository.GetAll();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                var selectedEntiry = dataGrid.SelectedItem as Customer;

                if (selectedEntiry != null)
                {

                    tbId.Text = selectedEntiry.CustomerID.ToString();
                    tbFullName.Text = selectedEntiry.CustomerFullName;
                    tbTelephone.Text = selectedEntiry.Telephone;
                    tbEmail.Text = selectedEntiry.EmailAddress;
                    tbBirthday.Text = selectedEntiry.CustomerBirthday.ToString();
                    tbStatus.Text = selectedEntiry.CustomerStatus.ToString();

                    currentSelect = selectedEntiry;
                    if (selectedEntiry.CustomerStatus.ToString() == CustomerStatus.Active.ToString())
                    {
                        btn_SwitchStatus.Content = CustomerStatus.Deleted.ToString();
                    }
                    else
                    {
                        btn_SwitchStatus.Content = CustomerStatus.Active.ToString();
                    }
                }
            }
        }

        private void btn_Delete(object sender, RoutedEventArgs e)
        {
            if (currentSelect == null) return;

            if (btn_SwitchStatus.Content.ToString() == CustomerStatus.Active.ToString())
            {
                btn_SwitchStatus.Content = CustomerStatus.Deleted.ToString();
                customerRepository.UpdateCustomerStatus(currentSelect, CustomerStatus.Active);
                tbStatus.Text = currentSelect.CustomerStatus.ToString();
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    btn_SwitchStatus.Content = CustomerStatus.Active.ToString();
                    customerRepository.UpdateCustomerStatus(currentSelect, CustomerStatus.Deleted);
                    tbStatus.Text = currentSelect.CustomerStatus.ToString();
                }
            }
            UpdateDataGrid();
        }

        private void btn_SearchByName(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchbyText.Text))
            {
                UpdateDataGrid();
            }
            else
            {
                dataGrid.ItemsSource = customerRepository.FindByName(tbSearchbyText.Text);
            }
        }
    }
}
