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
    /// Interaction logic for WindowUpdateRoom.xaml
    /// </summary>
    public partial class WindowUpdateRoom : Window
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRoomInformationRepository _roomRepository;
        private readonly P_RoomManagement roomManagementPage;
        private RoomInformation room;

        public WindowUpdateRoom(RoomInformation room, P_RoomManagement roomManagement)
        {
            InitializeComponent();

            this.room = room;
            _roomRepository = DIService.Instance.ServiceProvider.GetService<IRoomInformationRepository>();
            _roomTypeRepository = DIService.Instance.ServiceProvider.GetService<IRoomTypeRepository>();
            this.roomManagementPage = roomManagement;

            cb_Status.ItemsSource = Enum.GetValues(typeof(RoomStatus));
            List<RoomType> roomTypes = _roomTypeRepository.GetAll();
            cb_RoomType.ItemsSource = roomTypes;

            tb_RoomNumber.Text = room.RoomNumber;
            tb_RoomDescription.Text = room.RoomDescription;
            tb_RoomMaxCapacity.Text = room.RoomMaxCapacity.ToString();
            tb_PricePerDate.Text = room.RoomPricePerDate.ToString();
            cb_Status.Text = room.RoomStatus.ToString();
            cb_RoomType.Text = room.RoomType.RoomTypeName;
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

            room.RoomNumber = roomnNumber;
            room.RoomDescription = roomDesciption;
            room.RoomMaxCapacity = maxCapacity;
            room.RoomPricePerDate = pricePerDate;
            room.RoomStatus = roomStatus;
            room.RoomType = roomType;
            room.RoomTypeID = roomType.RoomTypeID;

            _roomRepository.Update(room);

            MessageBox.Show("Update Room Succesfully!");
            roomManagementPage.UpdateDataGrid();
            roomManagementPage.UpdateRoomSelected();
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
