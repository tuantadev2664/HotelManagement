using BusinessObjects;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoomTypeRepository(RoomTypeDAO roomTypeDAO) : IRoomTypeRepository
    {
        private readonly RoomTypeDAO _roomTypeDAO = roomTypeDAO;

        public List<RoomType> GetAll()
        {
            return _roomTypeDAO.GetAll();
        }

        public RoomType GetByName(string name)
        {
            return _roomTypeDAO.GetAll()
                .Where(r => r.RoomTypeName.Equals(name))
                .FirstOrDefault();
        }
    }
}
