using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _bookingService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddAbout(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAbout(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdAbout(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }

        [HttpPut("BookingStatusChangeApproved")]
        public IActionResult BookingStatusChangeApproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved(id);
            return Ok();
        }

    }
}
