using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BookingReservation
    {
        public int BookingReservationID { get; set; }

        [DataType(DataType.Date)]
        public DateOnly BookingDate { get; set; }

        public Decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }

    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
}
