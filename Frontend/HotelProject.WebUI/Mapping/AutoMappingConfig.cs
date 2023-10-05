using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonialDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<HomeResultServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();


            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();

            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();

            CreateMap<ResultGuestDto, Room>().ReverseMap();
            CreateMap<UpdateGuestDto, Room>().ReverseMap();
            CreateMap<CreateGuestDto, Room>().ReverseMap();

        }
    }
}
