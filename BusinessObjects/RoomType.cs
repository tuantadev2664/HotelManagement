using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomTypeName { get; set; }

        [StringLength(250)]
        public string? TypeDescription { get; set; }

        [StringLength(250)]
        public string? TypeNote { get; set; }

        public virtual ICollection<RoomInformation> Rooms { get; set; }
    }
}
