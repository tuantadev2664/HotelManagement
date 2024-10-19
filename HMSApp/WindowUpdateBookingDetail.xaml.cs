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
using static HMSApp.P_BookingDetail;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for WindowUpdateBookingDetail.xaml
    /// </summary>
    public partial class WindowUpdateBookingDetail : Window
    {
        private DateTime fromDate;
        private DateTime toDate;

        private readonly P_BookingDetail bookDetailPage;

        private BookingDetailVM bookingDetailVM;
        public WindowUpdateBookingDetail(BookingDetailVM bookingDetailVM, P_BookingDetail bookDetailPage)
        {
            InitializeComponent();

            this.bookingDetailVM = bookingDetailVM;
            this.bookDetailPage = bookDetailPage;

            dp_StartDate.SelectedDate = new DateTime(bookingDetailVM.StartDate.Year,
                                       bookingDetailVM.StartDate.Month,
                                       bookingDetailVM.StartDate.Day);

            fromDate = dp_StartDate.SelectedDate.Value;

            dp_EndtDate.SelectedDate = new DateTime(bookingDetailVM.EndDate.Year,
                                                  bookingDetailVM.EndDate.Month,
                                                  bookingDetailVM.EndDate.Day);

            toDate = dp_EndtDate.SelectedDate.Value;
        }

        private void FromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker datePicker && datePicker.SelectedDate.HasValue)
            {
                fromDate = datePicker.SelectedDate.Value;
                DateTime selectedDate = datePicker.SelectedDate.Value;
                //MessageBox.Show($"From Date selected: {selectedDate.ToShortDateString()}");
            }
        }

        private void ToDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker datePicker && datePicker.SelectedDate.HasValue)
            {
                toDate = datePicker.SelectedDate.Value;
                DateTime selectedDate = datePicker.SelectedDate.Value;
                //MessageBox.Show($"To Date selected: {selectedDate.ToShortDateString()}");
            }
        }

        private void btn_submit(object sender, RoutedEventArgs e)
        {
            if (!IsAllTextboxEntered())
            {
                MessageBox.Show("Please input all field!");
                return;
            }
            if (toDate.CompareTo(fromDate) <= 0)
            {
                MessageBox.Show($"Invalid Pick Date, try again!");
                return;
            }
            bookingDetailVM.StartDate = DateOnly.FromDateTime(fromDate);
            bookingDetailVM.EndDate = DateOnly.FromDateTime(toDate);

            bookingDetailVM.ActualPrice = CalculateDaysBetween(bookingDetailVM.StartDate, bookingDetailVM.EndDate) * bookingDetailVM.RoomInformation.RoomPricePerDate;
            bookingDetailVM.NumberOfDay = Convert.ToInt32(CalculateDaysBetween(bookingDetailVM.StartDate, bookingDetailVM.EndDate));
            foreach (var bookingDetail in P_BookingDetail.bookingDetailVMs)
            {
                if (bookingDetail.RoomID == bookingDetailVM.RoomID)
                {
                    bookingDetail.BookingReservationID = bookingDetailVM.BookingReservationID;
                    bookingDetail.RoomID = bookingDetailVM.RoomID;
                    bookingDetail.StartDate = bookingDetailVM.StartDate;
                    bookingDetail.EndDate = bookingDetailVM.EndDate;
                    bookingDetail.ActualPrice = bookingDetailVM.ActualPrice;
                    bookingDetail.BookingReservation = bookingDetailVM.BookingReservation;
                    bookingDetail.RoomInformation = bookingDetailVM.RoomInformation;
                    bookingDetail.NumberOfDay = bookingDetailVM.NumberOfDay;
                    break;
                }
            }

            MessageBox.Show("Update Room Succesfully!");
            bookDetailPage.UpdateDataGrid();
            bookDetailPage.UpdateBookingDetailVMSelected();
            this.Close();
           
        }

        private void btn_cancel(object sender, RoutedEventArgs e)
        {

            Close();
        }
        private bool IsAllTextboxEntered()
        {
            if (fromDate == DateTime.MinValue && toDate == DateTime.MinValue) return false;
            return true;
        }

        private int CalculateDaysBetween(DateOnly fromDate, DateOnly toDate)
        {
            return (toDate.ToDateTime(TimeOnly.MinValue) - fromDate.ToDateTime(TimeOnly.MinValue)).Days;
        }
    }
}
