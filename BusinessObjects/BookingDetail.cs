using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BookingDetail
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
    }
}
