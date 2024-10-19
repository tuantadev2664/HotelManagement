using BusinessObjects;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for WindowCreateBooking.xaml
    /// </summary>
    public partial class WindowCreateBooking : Window
    {
        private RoomInformation roomInformation;
        private BookingDetail bookingDetail;
        private Customer customer;

        public static event EventHandler<BookingDetail> OnGoToBookingDetail;
        public WindowCreateBooking(BookingDetail bookingDetail, Customer customer)
        {
            InitializeComponent();

            this.bookingDetail = bookingDetail;
            this.customer = customer;
            

            tb_RoomNumber.Text = bookingDetail.RoomInformation.RoomNumber;
            tb_RoomDescription.Text = bookingDetail.RoomInformation.RoomDescription;
            tb_RoomMaxCapacity.Text = bookingDetail.RoomInformation.RoomMaxCapacity.ToString();
            tb_PricePerDate.Text = bookingDetail.RoomInformation.RoomPricePerDate.ToString();
            tb_Status.Text = bookingDetail.RoomInformation.RoomStatus.ToString();
            tb_RoomType.Text = bookingDetail.RoomInformation.RoomType.RoomTypeName;

            tbStartDate.Text = bookingDetail.StartDate.ToString();
            tbEndDate.Text = bookingDetail.EndDate.ToString();
            tbActualPrice.Text = bookingDetail.ActualPrice.ToString();
            tbNumOfDate.Text = (bookingDetail.ActualPrice / bookingDetail.RoomInformation.RoomPricePerDate).ToString();

        }

        private void btn_choose(object sender, RoutedEventArgs e)
        {


            OnGoToBookingDetail?.Invoke(this, bookingDetail);
            this.Close();
        }

        private void btn_cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
