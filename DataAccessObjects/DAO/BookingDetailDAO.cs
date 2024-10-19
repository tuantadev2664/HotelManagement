using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookingDetailDAO(ApplicationDbContext applicationDbContext) : IDataAccessObject<BookingDetail>
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public void Add(BookingDetail bookingDetail)
        {
            _applicationDbContext.BookingDetails.Add(bookingDetail);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(BookingDetail bookingDetail)
        {
            _applicationDbContext.BookingDetails.Remove(bookingDetail);
            _applicationDbContext.SaveChanges();
        }


        public List<BookingDetail> GetAll()
        {
            return _applicationDbContext.BookingDetails.ToList();
        }

        public BookingDetail GetById(int bookingReservationId)
        {
            return _applicationDbContext.BookingDetails
                .Where(bd => bd.BookingReservationID == bookingReservationId)
                .FirstOrDefault();
        }

        public BookingDetail GetById(int bookingReservationId, int roomId)
        {
            return _applicationDbContext.BookingDetails
                .Where(bd => bd.BookingReservationID == bookingReservationId && bd.RoomID == roomId)
                .FirstOrDefault();
        }

        public void Update(BookingDetail entity)
        {

            try
            {
                _applicationDbContext.Entry<BookingDetail>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //    var existingBookingDetail = _applicationDbContext.BookingDetails
            //.FirstOrDefault(bd => bd.BookingReservationID == entity.BookingReservationID && bd.RoomID == entity.RoomID);

            //    if (existingBookingDetail != null)
            //    {
            //        existingBookingDetail.StartDate = entity.StartDate;
            //        existingBookingDetail.EndDate = entity.EndDate;
            //        existingBookingDetail.ActualPrice = entity.ActualPrice;

            //        _applicationDbContext.SaveChanges();
            //    }
            //    else
            //    {
            //        throw new Exception("BookingDetail not found in the database.");
            //        //Add(entity);
            //    }
        }
    }
}
