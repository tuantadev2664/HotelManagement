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
using static MaterialDesignThemes.Wpf.Theme;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for P_RoomManagement.xaml
    /// </summary>
    public partial class P_RoomManagement : Page
    {
        private RoomInformation currentSelect;
        private readonly IRoomInformationRepository _roomRepository;
        private readonly IBookingDetailRepository _bookingDetailRepository;
        public P_RoomManagement()
        {
            InitializeComponent();

            _bookingDetailRepository = DIService.Instance.ServiceProvider.GetService<IBookingDetailRepository>();
            _roomRepository = DIService.Instance.ServiceProvider.GetService<IRoomInformationRepository>();
            UpdateDataGrid();
        }

        public void UpdateDataGrid() => dataGrid.ItemsSource = _roomRepository.GetAll();

        public void UpdateRoomSelected()
        {
            tbId.Text = currentSelect.RoomID.ToString();
            tbRoomNumber.Text = currentSelect.RoomNumber;
            tbDescription.Text = currentSelect.RoomDescription;
            tbMaxCapacity.Text = currentSelect.RoomMaxCapacity.ToString();
            tbStatus.Text = currentSelect.RoomStatus.ToString();
            tbPricePerDate.Text = currentSelect.RoomPricePerDate.ToString();
            tbRoomType.Text = currentSelect.RoomType.RoomTypeName.ToString();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btn_Create(object sender, RoutedEventArgs e)
        {
            var createWindown = new WindowCreateRoom(this);
            createWindown.Show();
        }

        private void btn_Update(object sender, RoutedEventArgs e)
        {
            if (currentSelect == null) return;
            var updateWindown = new WindowUpdateRoom(currentSelect, this);
            updateWindown.Show();
        }

        private void btn_Delete(object sender, RoutedEventArgs e)
        {
            if (currentSelect == null) return;
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                var bookingDetail = _bookingDetailRepository.GetAll().Where(br => br.RoomID == currentSelect.RoomID).FirstOrDefault();
                if(bookingDetail != null)
                {
                    var room = _roomRepository.FindById(currentSelect.RoomID);
                    room.RoomStatus = RoomStatus.Deleted;
                    _roomRepository.Update(room);
                    UpdateDataGrid();
                    return;
                }

                _roomRepository.Delete(currentSelect);
                currentSelect = null;
                UpdateDataGrid();

                tbId.Text = string.Empty;
                tbRoomNumber.Text = string.Empty;
                tbDescription.Text = string.Empty;
                tbMaxCapacity.Text = string.Empty;
                tbStatus.Text = string.Empty;
                tbPricePerDate.Text = string.Empty;
                tbRoomType.Text = string.Empty;
            }
        }

        private void btn_SearchById(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchbyText.Text))
            {
                UpdateDataGrid();
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
                    MessageBox.Show(ex.Message, "Error");
                    throw;
                }


                RoomInformation room = _roomRepository.GetById(id);

                if (room == null)
                {
                    MessageBox.Show("Not find");
                }
                else
                {
                    dataGrid.ItemsSource = new List<RoomInformation>() { room };
                }
            }
        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (sender is System.Windows.Controls.DataGrid dataGrid)
            {
                var selectedEntiry = dataGrid.SelectedItem as RoomInformation;

                if (selectedEntiry != null)
                {
                    tbId.Text = selectedEntiry.RoomID.ToString();
                    tbRoomNumber.Text = selectedEntiry.RoomNumber;
                    tbDescription.Text = selectedEntiry.RoomDescription;
                    tbMaxCapacity.Text = selectedEntiry.RoomMaxCapacity.ToString();
                    tbStatus.Text = selectedEntiry.RoomStatus.ToString();
                    tbPricePerDate.Text = selectedEntiry.RoomPricePerDate.ToString();
                    tbRoomType.Text = selectedEntiry.RoomType.RoomTypeName.ToString();

                    currentSelect = selectedEntiry;
                }
            }
        }
    }
}
