using HotelProject.DataAccessLayer.Abstract;
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
    public class EfBookingDal : GenericRepositoryDal<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangeApproved(int id)
        {
            var context = new Context();
            var item = context.Bookings.Find(id);
            item.Status = "Onaylandı";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            var c = new Context();
            return c.Bookings.Count();
        }
    }
}
