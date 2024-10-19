using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoomTypeDAO(ApplicationDbContext applicationDbContext) : IDataAccessObject<RoomType>
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public void Add(RoomType entity)
        {
            _applicationDbContext.RoomTypes.Add(entity);
            _applicationDbContext.SaveChanges();

        }

        public void Delete(RoomType entity)
        {
            _applicationDbContext.RoomTypes.Remove(entity);
            _applicationDbContext.SaveChanges();

        }

        public List<RoomType> GetAll()
        {
            return _applicationDbContext.RoomTypes.ToList();
        }

        public RoomType GetById(int id)
        {
            return _applicationDbContext.RoomTypes
                    .Where(RoomType => RoomType.RoomTypeID == id)
                   .FirstOrDefault();
        }

        public void Update(RoomType entity)
        {
            foreach (var roomType in _applicationDbContext.RoomTypes)
            {
                if (roomType.RoomTypeID == entity.RoomTypeID)
                {
                    roomType.RoomTypeName = entity.RoomTypeName;
                    roomType.TypeDescription = entity.TypeDescription;
                    roomType.TypeNote = entity.TypeNote;
                    break;
                }
            }
        }
    }
}
