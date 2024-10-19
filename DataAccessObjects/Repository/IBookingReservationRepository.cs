using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookingReservationRepository
    {
        public ObservableCollection<BookingReservation> GetAll();

        public ObservableCollection<BookingReservation> GetAllByCustomer(Customer customer);

        public ObservableCollection<BookingReservation> GetAllConfirmed();
        public void Add(BookingReservation entity);
        public void Delete(BookingReservation entity);

        public BookingReservation GetById(int id);

        public void Update (BookingReservation entity);
    }
}
