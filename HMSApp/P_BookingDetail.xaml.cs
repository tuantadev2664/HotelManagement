using BusinessObjects;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
using static HMSApp.P_BookingDetail;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for P_BookRoom.xaml
    /// </summary>
    /// 
    public delegate void TabChangeHandler(int tabIndex);

    public class BookingDetailVM
    {
        public int BookingReservationID { get; set; }
        public int RoomID { get; set; }
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateOnly EndDate { get; set; }
        public decimal ActualPrice { get; set; }

        public virtual BookingReservation BookingReservation { get; set; }

        public virtual RoomInformation RoomInformation { get; set; }

        public int NumberOfDay { get; set; }
    }
    public partial class P_BookingDetail : Page
    {

        private readonly IBookingDetailRepository _bookingDetailRepository;
        private readonly IBookingReservationRepository _bookingReservationRepository;
       

        public static event TabChangeHandler OnTabChange;

        private BookingDetailVM currentSelect;
        private Customer customer;
        private decimal totalPrice = 0;

        private static BookingReservation BookingReservation;

        public  static ObservableCollection<BookingDetailVM> bookingDetailVMs;

        public P_BookingDetail()
        {
            InitializeComponent();
            tb_TotalPrice.Text = totalPrice.ToString() + " $";
        }

        public P_BookingDetail(BookingReservation bookingReservation)
        {
            InitializeComponent();

            _bookingDetailRepository = DIService.Instance.ServiceProvider.GetService<IBookingDetailRepository>();

            _bookingReservationRepository = DIService.Instance.ServiceProvider.GetService<IBookingReservationRepository>();

            BookingReservation = bookingReservation;

            bookingDetailVMs = new ObservableCollection<BookingDetailVM>();
            foreach (var bookingDetail in bookingReservation.BookingDetails)
            {
                var bookingDetailVM = new BookingDetailVM
                {
                    BookingReservationID = bookingDetail.BookingReservationID,
                    RoomID = bookingDetail.RoomID,
                    StartDate = bookingDetail.StartDate,
                    EndDate = bookingDetail.EndDate,
                    ActualPrice = bookingDetail.ActualPrice,
                    BookingReservation = bookingDetail.BookingReservation,
                    RoomInformation = bookingDetail.RoomInformation,
                    NumberOfDay = Convert.ToInt32(bookingDetail.ActualPrice / bookingDetail.RoomInformation.RoomPricePerDate)
                };
                bookingDetailVMs.Add(bookingDetailVM);

            }

            dataGrid.ItemsSource = bookingDetailVMs;
            totalPrice = bookingReservation.TotalPrice;
            tb_TotalPrice.Text = totalPrice.ToString() + " $";
        }

        public P_BookingDetail(BookingDetail? bookingDetail, Customer customer)
        {
            InitializeComponent();

            _bookingDetailRepository = DIService.Instance.ServiceProvider.GetService<IBookingDetailRepository>();

            _bookingReservationRepository = DIService.Instance.ServiceProvider.GetService<IBookingReservationRepository>();

            this.customer = customer;

            if (bookingDetailVMs == null)
            {
                bookingDetailVMs = new ObservableCollection<BookingDetailVM>();
            }
            
            if(bookingDetail != null)
            {
                var bookingDetailVM = new BookingDetailVM
                {
                    BookingReservationID = BookingReservation != null? BookingReservation.BookingReservationID : bookingDetail.BookingReservationID,
                    RoomID = bookingDetail.RoomID,
                    StartDate = bookingDetail.StartDate,
                    EndDate = bookingDetail.EndDate,
                    ActualPrice = bookingDetail.ActualPrice,
                    BookingReservation = bookingDetail.BookingReservation,
                    RoomInformation = bookingDetail.RoomInformation,
                    NumberOfDay = Convert.ToInt32(bookingDetail.ActualPrice / bookingDetail.RoomInformation.RoomPricePerDate)
                };

                // Kiểm tra xem item đã tồn tại chưa
                var existingItem = bookingDetailVMs.FirstOrDefault(x => x.RoomID == bookingDetail.RoomID);
                if (existingItem != null)
                {
                    MessageBox.Show("Exist!");
                    dataGrid.ItemsSource = bookingDetailVMs;
                    return;
                }
                else
                {
                    bookingDetailVMs.Add(bookingDetailVM);
                }
            }

            dataGrid.ItemsSource = bookingDetailVMs;

            totalPrice = 0;
            foreach (var bookingDetailVM in bookingDetailVMs)
            {
                totalPrice += bookingDetailVM.ActualPrice;
            }
            tb_TotalPrice.Text = totalPrice.ToString() + " $";
        }

        public void UpdateDataGrid()
        {
            var temp = new ObservableCollection<BookingDetailVM>();
            totalPrice = 0;

            foreach(var bookingDetailVM in bookingDetailVMs)
            {
                temp.Add(bookingDetailVM);
                totalPrice += bookingDetailVM.ActualPrice;
            }
            
            tb_TotalPrice.Text = totalPrice.ToString() + " $";
          
            dataGrid.ItemsSource = temp;
        }
        
        public void ResetBookingDetail()
        {
            BookingDetailVMsDelete = new ObservableCollection<BookingDetailVM>();
            bookingDetailVMs = new ObservableCollection<BookingDetailVM>();
        }

        public void UpdateBookingDetailVMSelected()
        {
            tbBookingReservationId.Text = currentSelect.BookingReservationID.ToString();
            tbRoomNumber.Text = currentSelect.RoomInformation.RoomNumber;
            tbDescription.Text = currentSelect.RoomInformation.RoomDescription;
            tbMaxCapacity.Text = currentSelect.RoomInformation.RoomMaxCapacity.ToString();
            tbStatus.Text = currentSelect.RoomInformation.RoomStatus.ToString();
            tbPricePerDate.Text = currentSelect.RoomInformation.RoomPricePerDate.ToString();
            tbRoomType.Text = currentSelect.RoomInformation.RoomType.RoomTypeName.ToString();
            tbStartDate.Text = currentSelect.StartDate.ToString();
            tbEndDate.Text = currentSelect.EndDate.ToString();
            tbActualPrice.Text = currentSelect.ActualPrice.ToString();
            tbNumOfDate.Text = currentSelect.NumberOfDay.ToString();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                var selectedEntiry = dataGrid.SelectedItem as BookingDetailVM;
                if (selectedEntiry != null)
                {
                    tbBookingReservationId.Text = selectedEntiry.BookingReservationID.ToString();
                    tbRoomNumber.Text = selectedEntiry.RoomInformation.RoomNumber;
                    tbDescription.Text = selectedEntiry.RoomInformation.RoomDescription;
                    tbMaxCapacity.Text = selectedEntiry.RoomInformation.RoomMaxCapacity.ToString();
                    tbStatus.Text = selectedEntiry.RoomInformation.RoomStatus.ToString();
                    tbPricePerDate.Text = selectedEntiry.RoomInformation.RoomPricePerDate.ToString();
                    tbRoomType.Text = selectedEntiry.RoomInformation.RoomType.RoomTypeName.ToString();
                    tbStartDate.Text = selectedEntiry.StartDate.ToString();
                    tbEndDate.Text = selectedEntiry.EndDate.ToString();
                    tbActualPrice.Text = selectedEntiry.ActualPrice.ToString();
                    tbNumOfDate.Text = selectedEntiry.NumberOfDay.ToString();

                    currentSelect = selectedEntiry;
                }
            }
        }

        private void btn_ContinueBooking(object sender, RoutedEventArgs e)
        {
            if(customer == null)
            {
                MessageBox.Show("Admin do not Booking room for Customer");
                return;
            }
            if (NavigationService.CanGoBack)
            {
                //NavigationService.GoBack();

                // Gửi thông báo thay đổi tab trước khi quay lại
                OnTabChange?.Invoke(1); // 0 là index của tab Booking
                //NavigationService.GoBack();
            }

        }

        private void btn_Update(object sender, RoutedEventArgs e)
        {
            if (currentSelect == null) return;
            var updateWindown = new WindowUpdateBookingDetail(currentSelect, this);
            updateWindown.Show();
        }

        public static ObservableCollection<BookingDetailVM> BookingDetailVMsDelete;

        private void btn_Delete(object sender, RoutedEventArgs e)
        {
            if (currentSelect == null) return;
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                //_roomRepository.Delete(currentSelect);
                bookingDetailVMs.Remove(currentSelect);

                if(BookingDetailVMsDelete == null)
                {
                    BookingDetailVMsDelete = new ObservableCollection<BookingDetailVM>();
                }

                BookingDetailVMsDelete.Add(currentSelect);

                currentSelect = null;
                UpdateDataGrid();

                tbBookingReservationId.Text = string.Empty;
                tbRoomNumber.Text = string.Empty;
                tbDescription.Text = string.Empty;
                tbMaxCapacity.Text = string.Empty;
                tbStatus.Text = string.Empty;
                tbPricePerDate.Text = string.Empty;
                tbRoomType.Text = string.Empty;
                tbStartDate.Text = string.Empty;
                tbEndDate.Text = string.Empty;
                tbActualPrice.Text = string.Empty;
                tbNumOfDate.Text = string.Empty;

            }
        }

        private void btn_SearchByRoomNumber(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchbyText.Text))
            {
                UpdateDataGrid();
                MessageBox.Show("Select a row");
            }
            else
            {
               
                foreach (var bookingDetail in bookingDetailVMs)
                {
                    if (bookingDetail.RoomInformation.RoomNumber == tbSearchbyText.Text)
                    {
                        currentSelect = bookingDetail;
                        break;
                    }
                }


                if (currentSelect == null)
                {
                    MessageBox.Show("Not find");
                }
                else
                {
                    tbSearchbyText.Text = string.Empty;
                    dataGrid.ItemsSource = new List<BookingDetailVM>{ currentSelect };
                }
            }
        }

        private void btn_CompleteBooking(object sender, RoutedEventArgs e)
        {
            if (BookingReservation != null)
            {
                if(totalPrice == 0)
                {
                    var tempBookingReservation = _bookingReservationRepository.GetById(BookingReservation.BookingReservationID);
                    tempBookingReservation.BookingStatus = BookingStatus.Cancelled;
                    _bookingReservationRepository.Update(tempBookingReservation);
                    MessageBox.Show("Cancel Booking successful");
                }
                else
                {

                    foreach (var bookingDetail in bookingDetailVMs)
                    {
                        var tempBookingDetail = _bookingDetailRepository.GetById(bookingDetail.BookingReservationID, bookingDetail.RoomID);
                        if (tempBookingDetail != null)
                        {
                            tempBookingDetail.StartDate = bookingDetail.StartDate;
                            tempBookingDetail.EndDate = bookingDetail.EndDate;
                            tempBookingDetail.ActualPrice = bookingDetail.ActualPrice;
                            _bookingDetailRepository.Update(tempBookingDetail);
                        }
                        else
                        {
                            BookingDetail newBookingDetail = new BookingDetail()
                            {
                                BookingReservationID = bookingDetail.BookingReservationID,
                                RoomID = bookingDetail.RoomID,
                                StartDate = bookingDetail.StartDate,
                                EndDate = bookingDetail.EndDate,
                                ActualPrice = bookingDetail.ActualPrice
                            };
                            _bookingDetailRepository.Add(newBookingDetail);
                        }

                    }
                    
                    if(BookingDetailVMsDelete != null)
                    {
                        foreach (var bookingDetail in BookingDetailVMsDelete)
                        {
                            var tempBookingDetail = _bookingDetailRepository.GetById(bookingDetail.BookingReservationID, bookingDetail.RoomID);
                            if (tempBookingDetail != null)
                            {
                                _bookingDetailRepository.Delete(tempBookingDetail);
                            }
                        }
                    }

                    

                    BookingDetailVMsDelete = new ObservableCollection<BookingDetailVM>();

                    var tempBookingReservation = _bookingReservationRepository.GetById(BookingReservation.BookingReservationID);
                    tempBookingReservation.TotalPrice = totalPrice;
                    tempBookingReservation.BookingStatus = BookingStatus.Pending;
                    _bookingReservationRepository.Update(tempBookingReservation);

                    MessageBox.Show("Save successful");
                    bookingDetailVMs = new ObservableCollection<BookingDetailVM>();
                    UpdateDataGrid();


                }
                
                
            }
            else if(totalPrice > 0)
            {
                BookingReservation bookingReservation = new BookingReservation()
                {
                    BookingDate = DateOnly.FromDateTime(DateTime.Now),
                    TotalPrice = totalPrice,
                    CustomerID = customer.CustomerID,
                    BookingStatus = BookingStatus.Pending,

                };
                _bookingReservationRepository.Add(bookingReservation);

                foreach (var bookingDetail in bookingDetailVMs)
                {
                    BookingDetail newBookingDetail = new BookingDetail()
                    {
                        BookingReservationID = bookingReservation.BookingReservationID,
                        RoomID = bookingDetail.RoomID,
                        StartDate = bookingDetail.StartDate,
                        EndDate = bookingDetail.EndDate,
                        ActualPrice = bookingDetail.ActualPrice
                    };
                    _bookingDetailRepository.Add(newBookingDetail);

                }
                MessageBox.Show("Booking successful");
                bookingDetailVMs = new ObservableCollection<BookingDetailVM>(); ;
                UpdateDataGrid();
            }

            tbBookingReservationId.Text = string.Empty;
            tbRoomNumber.Text = string.Empty;
            tbDescription.Text = string.Empty;
            tbMaxCapacity.Text = string.Empty;
            tbStatus.Text = string.Empty;
            tbPricePerDate.Text = string.Empty;
            tbRoomType.Text = string.Empty;
            tbStartDate.Text = string.Empty;
            tbEndDate.Text = string.Empty;
            tbActualPrice.Text = string.Empty;
            tbNumOfDate.Text = string.Empty;

        }

        
    }
}
