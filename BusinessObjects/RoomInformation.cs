using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class RoomInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomNumber { get; set; }

        [StringLength(220)]
        public string? RoomDescription { get; set; }

        public int? RoomMaxCapacity { get; set; }

        public RoomStatus RoomStatus { get; set; }

        [DataType(DataType.Currency)]
        public decimal RoomPricePerDate { get; set; }

        public int RoomTypeID { get; set; }

        public virtual RoomType RoomType { get; set; }

        public virtual ICollection<BookingDetail> BookingDetail { get; set; }

    }

    public enum RoomStatus
    {
        Active,
        Deleted
    }
}
