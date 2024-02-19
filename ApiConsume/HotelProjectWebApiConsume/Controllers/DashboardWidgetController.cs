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
        private readonly IRoomService _roomService;
        private readonly IAppUserService _appUserService;   

        public DashboardWidgetController(IStaffService staffService, IBookingService bookingService, IRoomService roomService, IAppUserService appUserService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _roomService = roomService;
            _appUserService = appUserService;
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

        [HttpGet("GetRoomCount")]
        public IActionResult GetRoomCount()
        {
            var values = _roomService.TGetRoomCount();   
            return Ok(values);
        }

        [HttpGet("GetAppUserCount")]
        public IActionResult GetAppUserCount()
        {
            var values = _appUserService.TGetAppUserCount();
            return Ok(values);
        }
    }
}
