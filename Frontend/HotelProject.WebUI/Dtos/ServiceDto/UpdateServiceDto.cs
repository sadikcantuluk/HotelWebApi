using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Hizmet iconu girin !")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet iconu girin !")]
        [StringLength(50, ErrorMessage = "50 karakteri geçmemeli !")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet açıklaması girin !")]
        [StringLength(200, ErrorMessage = "200 karakteri geçmemeli !")]
        public string Description { get; set; }

    }
}
