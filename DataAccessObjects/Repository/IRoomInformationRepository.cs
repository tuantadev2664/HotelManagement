using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoomInformationRepository
    {
        public ObservableCollection<RoomInformation> GetAll();
        public RoomInformation FindById(int id);

        public void Update(RoomInformation room);
        public void Add(RoomInformation room);
        public void Delete(RoomInformation room);
        public RoomInformation GetById(int id);
    }
}
