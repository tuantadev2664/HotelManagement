using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CustomerBookingRoom
    {
        [Required]
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public int RoomID { get; set; }

        public virtual RoomInformation RoomInformation { get; set; }

        [Required]
        public DateOnly FromDate { get; set; }

        [Required]
        public DateOnly ToDate { get; set; }
    }
}
