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
    public class RoomInformationRepository(RoomInformationDAO roomInformationDAO) : IRoomInformationRepository
    {
        private readonly RoomInformationDAO _roomInformationDAO = roomInformationDAO;

        public void Add(RoomInformation roomInformation)
        {
            _roomInformationDAO.Add(roomInformation);
        }

        public void Delete(RoomInformation roomInformation)
        {
            _roomInformationDAO.Delete(roomInformation);
        }

        public RoomInformation FindById(int id)
        {
            return _roomInformationDAO.GetById(id);
        }

        public ObservableCollection<RoomInformation> GetAll()
        {

            return _roomInformationDAO.GetAll_U();
        }

        public RoomInformation GetById(int id)
        {
            return _roomInformationDAO.GetById(id);
        }

        public void Update(RoomInformation room)
        {
            _roomInformationDAO.Update(room);
        }
    }
}
