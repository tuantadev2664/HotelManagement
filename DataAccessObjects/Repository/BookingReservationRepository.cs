using BusinessObjects;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookingReservationRepository(BookingReservationDAO bookingReservationDAO) : IBookingReservationRepository
    {
        private readonly BookingReservationDAO bookingReservationDAO = bookingReservationDAO;

        public void Add(BookingReservation bookingReservation)
        {
            bookingReservationDAO.Add(bookingReservation);
        }

        public void Delete(BookingReservation bookingReservation) 
        {
            bookingReservationDAO.Delete(bookingReservation);
        }

        public ObservableCollection<BookingReservation> GetAll() 
        {
            return bookingReservationDAO.GetAllReload();
        }

        public ObservableCollection<BookingReservation> GetAllByCustomer(Customer customer)
        {
            return new ObservableCollection < BookingReservation > (bookingReservationDAO.GetAllReload().Where(b => b.CustomerID == customer.CustomerID).ToList());
        }

        public ObservableCollection<BookingReservation> GetAllConfirmed()
        {
            var bookingReservationStatic = new ObservableCollection<BookingReservation>();
            foreach(var bookingReservation in GetAll()){
                if(bookingReservation.BookingStatus == BookingStatus.Confirmed)
                {
                    bookingReservationStatic.Add(bookingReservation);
                }
            }
            return bookingReservationStatic;
        }

        public BookingReservation GetById(int id)
        {
            return bookingReservationDAO.GetById(id);
        }

        public void Update(BookingReservation entity)
        {
            bookingReservationDAO.Update(entity);
        }

    }
}
