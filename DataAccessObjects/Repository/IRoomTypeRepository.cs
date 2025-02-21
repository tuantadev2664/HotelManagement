﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoomTypeRepository
    {
        public List<RoomType> GetAll();

        public RoomType GetByName(string name);
    }
}
