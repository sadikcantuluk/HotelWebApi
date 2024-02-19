using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;

        public DashboardWidgetController(IStaffService staffService, IBookingService bookingService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
        }

        [HttpGet("GetStaffCount")]
        public IActionResult GetStaffCount()
        {
            var values = _staffService.TGetStaffCount();
            return Ok(values);
        }

        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {
            var values = _bookingService.TGetBookingCount();
            return Ok(values);
        }
    }
}
