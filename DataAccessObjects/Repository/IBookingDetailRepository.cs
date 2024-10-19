using BusinessObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookingDetailRepository
    {
        public List<BookingDetail> GetAll();
        public void Add(BookingDetail entity);
        public void Delete(BookingDetail entity);
        public void Update(BookingDetail entity);
        public BookingDetail GetById(int bookingReservationId, int roomId);
    }
}
