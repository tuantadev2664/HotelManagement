using BusinessObjects;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookingDetailRepository(BookingDetailDAO bookingDetailDAO) : IBookingDetailRepository
    {
        private readonly BookingDetailDAO bookingDetailDAO = bookingDetailDAO;

        public void Add(BookingDetail entity)
        {
            bookingDetailDAO.Add(entity);
        }

        public void Delete(BookingDetail entity)
        {
            bookingDetailDAO.Delete(entity);
        }

        public List<BookingDetail> GetAll()
        {
            return bookingDetailDAO.GetAll();
        }

        public void Update(BookingDetail entity)
        {
            bookingDetailDAO.Update(entity);
        }

        public BookingDetail GetById(int bookingReservationId, int roomId)
        {
           return bookingDetailDAO.GetById(bookingReservationId, roomId);
        }

    }
}
