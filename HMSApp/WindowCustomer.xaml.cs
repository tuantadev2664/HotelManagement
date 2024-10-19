using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static HMSApp.P_BookingDetail;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for WindowCustomer.xaml
    /// </summary>
    public partial class WindowCustomer : Window
    {
        private readonly P_CustomerProfile customerProfilePage;
        private readonly P_BookingReservation bookingReservationPage;
        private readonly P_ReservationHistory reservationHistoryPage;

        private P_BookingDetail bookingDetailPage;

        private readonly NavigationManager _navigationManager;

        private EventHandler<BookingDetail> bookingHandler;

        public WindowCustomer(Customer customer)
        {
            InitializeComponent();

            _navigationManager = new NavigationManager(ContentFrame, tabControl);

            customerProfilePage = new P_CustomerProfile(customer);
            bookingReservationPage = new P_BookingReservation(customer);
            reservationHistoryPage = new P_ReservationHistory(customer);
            bookingDetailPage = new P_BookingDetail(null, customer);


            

            // Đăng ký sự kiện
            P_BookingDetail.OnTabChange += (tabIndex) =>
            {
                tabControl.SelectedIndex = tabIndex;
                ContentFrame.Navigate(bookingReservationPage);
            };

            // Gán lambda expression cho handler
            bookingHandler = (sender, data) =>
            {
                tabControl.SelectedIndex = 2;
                ContentFrame.Navigate(new P_BookingDetail(data, customer));
                //_navigationManager.NavigateTo(bookingDetailPage, 2);

                // Hủy đăng ký event ngay tại đây
                WindowCreateBooking.OnGoToBookingDetail -= bookingHandler;
            };

            // Đăng ký event với handler đã lưu
            WindowCreateBooking.OnGoToBookingDetail += bookingHandler;
        }



        public void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ContentFrame == null) return;

            var selectedTab = (sender as TabControl)?.SelectedIndex;

            switch (selectedTab)
            {
                case 0:
                    ContentFrame.Navigate(customerProfilePage);
                    break;

                case 1:
                    ContentFrame.Navigate(bookingReservationPage);
                    break;
                case 2:
                    ContentFrame.Navigate(bookingDetailPage);
                    break;
                case 3:
                    ContentFrame.Navigate(reservationHistoryPage);
                    break;
                case 4:
                    bookingDetailPage.ResetBookingDetail();
                    Login loginWindow = new Login();
                    loginWindow.Show();
                    this.Close();
                    break;
                case 5:
                    this.Close();
                    break;
            }
        }
    }
}
