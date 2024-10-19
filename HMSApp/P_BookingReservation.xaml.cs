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
    /// Interaction logic for P_BookingReservation.xaml
    /// </summary>
    public partial class P_BookingReservation : Page
    {
        private DateTime fromDate;
        private DateTime toDate;
        private RoomInformation currentSelect;
        private BookingReservation bookingReservation;
        private BookingDetail bookingDetail;
        private readonly IRoomInformationRepository _roomInformationRepository;
        private readonly IBookingDetailRepository _bookingDetailRepository;
        private readonly IBookingReservationRepository _bookingReservationRepository;
        private Customer customer;

        public P_BookingReservation(Customer? customer)
        {
            InitializeComponent();

            _roomInformationRepository = DIService.Instance.ServiceProvider.GetService<IRoomInformationRepository>();
            _bookingDetailRepository = DIService.Instance.ServiceProvider.GetService<IBookingDetailRepository>();
            _bookingReservationRepository = DIService.Instance.ServiceProvider.GetService<IBookingReservationRepository>();
            this.customer = customer;
            
        }

        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker datePicker && datePicker.SelectedDate.HasValue)
            {
                fromDate = datePicker.SelectedDate.Value;
                DateTime selectedDate = datePicker.SelectedDate.Value;
                //MessageBox.Show($"From Date selected: {selectedDate.ToShortDateString()}");
            }
        }

        private void EndDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker datePicker && datePicker.SelectedDate.HasValue)
            {
                toDate = datePicker.SelectedDate.Value;
                DateTime selectedDate = datePicker.SelectedDate.Value;
                //MessageBox.Show($"To Date selected: {selectedDate.ToShortDateString()}");
            }
        }

        private void UpdateDataGrid()  => dataGrid.ItemsSource = _roomInformationRepository.GetAll();

        private void NumOfPeopleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool IsTimeOverlap(DateTime fromDate, DateTime toDate ,BookingDetail  bookingDetail)
        {
            return DateOnly.FromDateTime(fromDate).CompareTo(bookingDetail.EndDate) < 0 && bookingDetail.StartDate.CompareTo(DateOnly.FromDateTime(toDate)) < 0;
        }

        private void Btn_Search(object sender, RoutedEventArgs e)
        {
            if (!IsAllTextboxEntered())
            {
                MessageBox.Show("Please input Start-End Date field!");
                return;
            }
            
            if (fromDate.CompareTo(DateTime.Now) < 0 && toDate.CompareTo(DateTime.Now) < 0)
            {
                MessageBox.Show("Not Booking Room in the PAST!");
                return;
            }

            if (fromDate.CompareTo(toDate) > 0)
            {
                MessageBox.Show("The Date Invalid!");
                return;
            }

            var bookingReservations = _bookingReservationRepository.GetAll()
                                .Where(br => br.BookingStatus == BookingStatus.Confirmed || br.BookingStatus == BookingStatus.Pending)
                                .ToList();
            
            var bookingDetails = bookingReservations.SelectMany(br => br.BookingDetails).ToList();



            var roomAvailable = _roomInformationRepository.GetAll()
                                 .Where(r => r.RoomStatus == RoomStatus.Active && !bookingDetails.Any(bookingDetail =>  bookingDetail.RoomID == r.RoomID && IsTimeOverlap(fromDate, toDate, bookingDetail)))
                                 .ToList();

            dataGrid.ItemsSource = roomAvailable;
            if(roomAvailable.Count() == 0)
            {
                MessageBox.Show("Hotel is Full Room in during please choose another during time");
            }
        }

        private void PriceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                var selectedEntiry = dataGrid.SelectedItem as RoomInformation;

                if (selectedEntiry != null)
                {
                    currentSelect = selectedEntiry;
                }
            }
        }

        private void btn_booking(object sender, RoutedEventArgs e)
        {
            if (!IsAllTextboxEntered())
            {
                MessageBox.Show("Please input Start-End Date field!");
                return;
            }
            if (currentSelect == null)
            {
                MessageBox.Show("Please choose room!");
                return;
            }
            
            if(fromDate.CompareTo(DateTime.Now) < 0 &&  toDate.CompareTo(DateTime.Now) < 0)
            {
                MessageBox.Show("Not Booking Room in the PAST!");
                return;
            }

            if (fromDate.CompareTo(toDate) > 0)
            {
                MessageBox.Show("The Date Invalid!");
                return;
            }


            bookingDetail = new BookingDetail();
            bookingDetail.RoomID = currentSelect.RoomID;
            bookingDetail.StartDate = DateOnly.FromDateTime(fromDate);
            bookingDetail.EndDate = DateOnly.FromDateTime(toDate);
            bookingDetail.ActualPrice = CalculateDaysBetween(bookingDetail.StartDate, bookingDetail.EndDate) * currentSelect.RoomPricePerDate;
            bookingDetail.RoomInformation = currentSelect;
            var createBooking = new WindowCreateBooking(bookingDetail, customer);
            createBooking.Show();
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
