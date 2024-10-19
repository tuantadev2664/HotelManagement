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
    /// Interaction logic for P_Static.xaml
    /// </summary>
    public partial class P_Static : Page
    {
        private DateTime fromDate;
        private DateTime toDate;
        private readonly IBookingReservationRepository _bookingReservationRepository;
        class Static{
            public DateOnly Date { get; set; }
            public int NumberOfCustomer { get; set; }
            public decimal Revenue { get; set; }
        }
        private static decimal totalRevenue = 0;

        public P_Static()
        {
            InitializeComponent();

            _bookingReservationRepository = DIService.Instance.ServiceProvider.GetService<IBookingReservationRepository>();

            totalRevenue = 0;
            tb_TotalRevenue.Text = totalRevenue + " $";

        }

        private void Upload()
        {
            if (IsAllTextboxEntered())
            {
                totalRevenue = 0;
                var bookingReservation = new ObservableCollection<BookingReservation>();

                foreach (var item in _bookingReservationRepository.GetAllConfirmed())
                {
                    if (item.BookingDate.CompareTo(DateOnly.FromDateTime(fromDate)) >= 0 && item.BookingDate.CompareTo(DateOnly.FromDateTime(toDate)) <= 0)
                        bookingReservation.Add(item);
                }
                dataGrid.ItemsSource = bookingReservation;

                foreach (var item in bookingReservation)
                {
                    totalRevenue += item.TotalPrice;
                }
                tb_TotalRevenue.Text = totalRevenue + " $";

                if (bookingReservation.Count == 0)
                {
                    MessageBox.Show($"Didn't have customer from {DateOnly.FromDateTime(fromDate)} to {DateOnly.FromDateTime(toDate)}!");
                }
                
            }
            else
            {
                totalRevenue = 0;
                dataGrid.ItemsSource = _bookingReservationRepository.GetAllConfirmed();

                foreach (var item in _bookingReservationRepository.GetAllConfirmed())
                {
                    totalRevenue += item.TotalPrice;
                }
                tb_TotalRevenue.Text = totalRevenue + " $";
            }
                
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

        private void btn_Sort(object sender, RoutedEventArgs e)
        {
            if (toDate.CompareTo(fromDate) < 0)
            {
                MessageBox.Show($"Invalid Pick Date, try again!");
            }
            else
            {
                Upload();
                //    var listStatic = new List<Static>();
                //    var customerBookRoomList = newList<>//_customerBookRoomRepository.GetAll();

                //    foreach (var customerBookRoom in customerBookRoomList)
                //    {
                //        DateOnly start = customerBookRoom.FromDate > DateOnly.FromDateTime(fromDate) ? customerBookRoom.FromDate : DateOnly.FromDateTime(fromDate);
                //        DateOnly end = customerBookRoom.ToDate < DateOnly.FromDateTime(toDate) ? customerBookRoom.ToDate : DateOnly.FromDateTime(toDate);

                //        foreach (DateOnly day in EachDay(start, end))
                //        {
                //            var staticNeedFind = listStatic.FirstOrDefault(sta => sta.Date.CompareTo(day) == 0);

                //            if (staticNeedFind == null)
                //            {
                //                staticNeedFind = new Static
                //                {
                //                    Date = day,
                //                    NumberOfCustomer = 0,
                //                    Revenue = 0
                //                };
                //                listStatic.Add(staticNeedFind);
                //            }

                //            staticNeedFind.NumberOfCustomer++;
                //            var room = _roomRepository.GetById(customerBookRoom.RoomID);
                //            if (room != null)
                //            {
                //                staticNeedFind.Revenue += room.RoomPricePerDate;
                //            }
                //        }
                //    }

                //    if (listStatic.Count > 0)
                //    {
                //        dataGrid.ItemsSource = listStatic.OrderByDescending(sta => sta.Revenue).ToList();
                //    }
                //    else
                //    {
                //        MessageBox.Show($"Didn't have customer from {DateOnly.FromDateTime(fromDate)} to {DateOnly.FromDateTime(toDate)}!");
                //    }
            }
        }



        public IEnumerable<DateOnly> EachDay(DateOnly from, DateOnly thru)
        {
            for (var day = from; day <= thru; day = day.AddDays(1))
            {
                yield return day;
            }
        }

        private bool IsAllTextboxEntered()
        {
            if (fromDate == DateTime.MinValue && toDate == DateTime.MinValue) return false;
            return true;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
