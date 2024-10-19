using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerFullName { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(12)]
        public string Telephone { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        public DateOnly CustomerBirthday { get; set; }

        public CustomerStatus CustomerStatus { get; set; }

        public virtual ICollection<BookingReservation> BookingReservations { get; set; }
    }

    public enum CustomerStatus
    {
        Active,
        Deleted
    }
}
