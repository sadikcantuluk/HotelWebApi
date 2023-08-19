using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Oda numaraını girin lütfen !")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Oda resmini yükleyin lütfen !")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Oda fiyatını girin lütfen !")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Oda başlığını girin lütfen !")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsin !")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Oda yatak sayısını girin lütfen !")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Oda banyo sayısını girin lütfen !")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }

        [Required(ErrorMessage = "Oda açıklama yazın lütfen !")]
        public string Description { get; set; }
    }
}
