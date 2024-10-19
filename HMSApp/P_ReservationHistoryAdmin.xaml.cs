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
using static MaterialDesignThemes.Wpf.Theme;
using Button = System.Windows.Controls.Button;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for P_ReservationHistoryAmin.xaml
    /// </summary>
    public partial class P_ReservationHistoryAdmin : Page
    {
        private readonly IBookingReservationRepository _bookingReservationRepository;

        public static event EventHandler<BookingReservation> OnGoToBookingDetail;
        public P_ReservationHistoryAdmin()
        {
            InitializeComponent();

            _bookingReservationRepository = DIService.Instance.ServiceProvider.GetService<IBookingReservationRepository>();


            var bookingReservationList = new ObservableCollection<BookingReservation>(_bookingReservationRepository.GetAll());

            this.DataContext = new
            {
                bookingReservationList = bookingReservationList
            };


        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Truy cập vào CommandParameter để nhận dữ liệu
                var data = button.CommandParameter;

                // Xử lý dữ liệu ở đây
                if (data != null)
                {

                    var bookingReservation = _bookingReservationRepository.GetById(Convert.ToInt32(data));
                    if (bookingReservation.BookingStatus != BookingStatus.Cancelled)
                    {
                        OnGoToBookingDetail?.Invoke(this, bookingReservation);
                        Upload();
                    }
                    else
                    {
                        MessageBox.Show("Booking is Cancelled");
                    }

                }
            }

        }


        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Truy cập vào CommandParameter để nhận dữ liệu
                var data = button.CommandParameter;

                // Xử lý dữ liệu ở đây
                if (data != null)
                {

                    var bookingReservation = _bookingReservationRepository.GetById(Convert.ToInt32(data));
                    if (bookingReservation.BookingStatus == BookingStatus.Confirmed)
                        MessageBox.Show("Booking is Confirmed");
                    else if (bookingReservation.BookingStatus == BookingStatus.Pending)
                    {
                        bookingReservation.BookingStatus = BookingStatus.Confirmed;
                        _bookingReservationRepository.Update(bookingReservation);
                        Upload();
                        MessageBox.Show("Booking is Confirmed");
                    }
                    else
                        MessageBox.Show("Booking is Cancelled");
                    
                }
            }
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Truy cập vào CommandParameter để nhận dữ liệu
                var data = button.CommandParameter;

                // Xử lý dữ liệu ở đây
                if (data != null)
                {

                    var bookingReservation = _bookingReservationRepository.GetById(Convert.ToInt32(data));
                    if (bookingReservation.BookingStatus == BookingStatus.Confirmed)
                        MessageBox.Show("Booking is Confirmed");
                    else if (bookingReservation.BookingStatus != BookingStatus.Cancelled)
                    {
                        bookingReservation.BookingStatus = BookingStatus.Cancelled;
                        _bookingReservationRepository.Update(bookingReservation);
                        Upload();
                        MessageBox.Show("Booking is Cancelled Successful");
                    }

                    else
                    {
                        MessageBox.Show("Booking is Cancelled");
                    }


                }
            }
        }

        public  void Upload()
        {
            var bookingReservationList = _bookingReservationRepository.GetAll();

            this.DataContext = new
            {
                bookingReservationList = bookingReservationList
            };
        }

        private void btn_Reload_Click(object sender, RoutedEventArgs e)
        {
            Upload();
        }

        private void btn_SearchByRoomNumber(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbSearchbyText.Text))
            {
                Upload();
            }
            else
            {
                int id;
                try
                {
                    id = int.Parse(tbSearchbyText.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error! Input Invale. Please Enter BookingId Of Customer.");
                    throw;
                }


                var bookingReservation = _bookingReservationRepository.GetById(Convert.ToInt32(tbSearchbyText.Text));

                if (bookingReservation == null)
                {
                    MessageBox.Show("Not find");
                }
                else
                {
                    this.DataContext = new
                    {
                        bookingReservationList = new List<BookingReservation>() { bookingReservation }
                    };
                
                }
            }
                
        }
    }
}

