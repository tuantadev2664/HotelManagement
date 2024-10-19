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
using System.Windows.Shapes;

namespace HMSApp
{
    /// <summary>
    /// Interaction logic for WindowCreateRoom.xaml
    /// </summary>
    public partial class WindowCreateRoom : Window
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRoomInformationRepository _roomRepository;
        private readonly P_RoomManagement roomManagementPage;

        public WindowCreateRoom(P_RoomManagement roomManagement)
        {
            InitializeComponent();

            _roomRepository = DIService.Instance.ServiceProvider.GetService<IRoomInformationRepository>();
            _roomTypeRepository = DIService.Instance.ServiceProvider.GetService<IRoomTypeRepository>();
            this.roomManagementPage = roomManagement;

            cb_Status.ItemsSource = Enum.GetValues(typeof(RoomStatus));
            List<RoomType> roomTypes = _roomTypeRepository.GetAll();
            cb_RoomType.ItemsSource = roomTypes;
        }

        public void btn_cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void btn_submit(object sender, RoutedEventArgs e)
        {
            if (!IsAllTextboxEntered())
            {
                MessageBox.Show("Please input all field!");
                return;
            }

            string roomnNumber = tb_RoomNumber.Text;
            string roomDesciption = tb_RoomDescription.Text;

            int maxCapacity;
            try
            {
                maxCapacity = int.Parse(tb_RoomMaxCapacity.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            decimal pricePerDate;
            try
            {
                pricePerDate = decimal.Parse(tb_PricePerDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            RoomStatus roomStatus = (RoomStatus)cb_Status.SelectedItem;
            RoomType roomType = (RoomType)cb_RoomType.SelectedItem;

            RoomInformation newRoom = new RoomInformation
            {
                RoomNumber = roomnNumber,
                RoomDescription = roomDesciption,
                RoomMaxCapacity = maxCapacity,
                RoomPricePerDate = pricePerDate,
                RoomStatus = roomStatus,
                RoomType = roomType,
                RoomTypeID = roomType.RoomTypeID
            };
            _roomRepository.Add(newRoom);
            MessageBox.Show("Add New Room Succesfully!");
            roomManagementPage.UpdateDataGrid();
            this.Close();
        }

        private bool IsAllTextboxEntered()
        {
            if (string.IsNullOrEmpty(tb_RoomNumber.Text)) return false;
            if (string.IsNullOrEmpty(tb_RoomDescription.Text)) return false;
            if (string.IsNullOrEmpty(tb_RoomMaxCapacity.Text)) return false;
            if (string.IsNullOrEmpty(tb_PricePerDate.Text)) return false;
            if (string.IsNullOrEmpty(cb_Status.Text)) return false;
            if (string.IsNullOrEmpty(cb_RoomType.Text)) return false;
            return true;
        }
    }
}
