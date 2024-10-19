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
    public class RoomInformationDAO(ApplicationDbContext applicationDbContext) : IDataAccessObject<RoomInformation>
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
        

        public void Add(RoomInformation entity)
        {
            
            
            _applicationDbContext.Rooms.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(RoomInformation entity)
        {
            _applicationDbContext.Rooms.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public List<RoomInformation> GetAll() { return null; }

        public ObservableCollection<RoomInformation> GetAll_U()
        {
            var roomInformations  = _applicationDbContext.Rooms
                .Include(r => r.RoomType)
                .ToList();

            //// Chuyển BookingDetails trong mỗi BookingReservation thành ObservableCollection
            //foreach (var room in roomInformations)
            //{
            //    room.RoomStatus = new ObservableCollection<RoomStatus>(room.RoomStatus);
            //}

            return new ObservableCollection<RoomInformation>(roomInformations);
        }

        public RoomInformation GetById(int id)
        {
            return _applicationDbContext.Rooms
                    .Where(r => r.RoomID == id)
                    .FirstOrDefault();
        }

        public void Update(RoomInformation entity)
        {
            try
            {
                _applicationDbContext.Entry<RoomInformation>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
