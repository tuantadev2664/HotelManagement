using BusinessObjects;
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
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        private readonly P_CustomerManagement customerManagementPage;
        private readonly P_RoomManagement roomManagementPage;
        private readonly P_Static staticPage;
        private readonly P_ReservationHistoryAdmin reservationHistoryAdminPage;
        private P_BookingDetail bookingDetailPage;

        private readonly NavigationManager _navigationManager;

        public WindowAdmin()
        {
            InitializeComponent();

            _navigationManager = new NavigationManager(ContentFrame, tabControl);

            customerManagementPage = new P_CustomerManagement();
            roomManagementPage = new P_RoomManagement();
            reservationHistoryAdminPage = new P_ReservationHistoryAdmin();
            staticPage = new P_Static();
            bookingDetailPage = new P_BookingDetail();


            P_ReservationHistoryAdmin.OnGoToBookingDetail += (sender, data) =>
            {
                bookingDetailPage = new P_BookingDetail(data);
                _navigationManager.NavigateTo(bookingDetailPage, 3);
            };
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ContentFrame == null) return;

            var selectedTab = (sender as TabControl)?.SelectedIndex;

            switch (selectedTab)
            {
                case 0:
                    ContentFrame.Navigate(customerManagementPage);
                    break;
                case 1:
                    ContentFrame.Navigate(roomManagementPage);
                    break;
                case 2:
                    reservationHistoryAdminPage.Upload();
                    ContentFrame.Navigate(reservationHistoryAdminPage);
                    break;
                case 3:
                    ContentFrame.Navigate(bookingDetailPage);
                    break;
                case 4:
                    ContentFrame.Navigate(staticPage);
                    break;
                case 5:
                    bookingDetailPage.ResetBookingDetail();
                    Login loginWindow = new Login();
                    loginWindow.Show();
                    this.Close();
                    break;
                case 6:
                    this.Close();
                    break;
            }
        }
    }
}
