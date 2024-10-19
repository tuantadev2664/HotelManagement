using BusinessObjects;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookingReservationDAO(ApplicationDbContext applicationDbContext) : IDataAccessObject<BookingReservation>
    {

        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;


        public void Add(BookingReservation bookingReservation)
        {
            _applicationDbContext.BookingReservations.Add(bookingReservation);
            _applicationDbContext.SaveChanges();

        }

        public void Delete(BookingReservation bookingReservation)
        {
            _applicationDbContext.BookingReservations.Remove(bookingReservation);
            _applicationDbContext.SaveChanges();

        }

        public List<BookingReservation> GetAll() { return null; }

        public ObservableCollection<BookingReservation> GetAllReload()
        {
            var bookings = _applicationDbContext.BookingReservations
                .Include(bd => bd.Customer)
         .Include(br => br.BookingDetails)
         .ThenInclude(bd => bd.RoomInformation)
         .ThenInclude(r => r.RoomType)
         .OrderBy(br => br.BookingStatus)
         .ThenByDescending(br => br.BookingDate)
         .ToList();

            // Chuyển BookingDetails trong mỗi BookingReservation thành ObservableCollection
            foreach (var booking in bookings)
            {
                booking.BookingDetails = new ObservableCollection<BookingDetail>(booking.BookingDetails);
            }

            return new ObservableCollection<BookingReservation>(bookings);
        }

        public BookingReservation GetById(int id)
        {
            return _applicationDbContext.BookingReservations
                .Where(br => br.BookingReservationID == id)
                .FirstOrDefault();
        }

        public void Update(BookingReservation bookingReservation)
        {
            try
            {
                _applicationDbContext.Entry<BookingReservation>(bookingReservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
