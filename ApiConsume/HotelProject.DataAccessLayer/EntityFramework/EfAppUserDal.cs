﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepositoryDal<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public int GetAppUserCount()
        {
            var c = new Context();
            return c.Users.Count();
        }
    }
}
