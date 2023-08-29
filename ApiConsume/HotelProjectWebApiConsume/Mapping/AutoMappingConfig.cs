using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;

namespace HotelProjectWebApiConsume.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<AddRoomDto, Room>();
            CreateMap<Room, AddRoomDto>();

            //Veya kısa yol ile;

            CreateMap<Room, UpdateRoomDto>().ReverseMap();

            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
        }
    }
}
