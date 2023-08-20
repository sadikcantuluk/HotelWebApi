using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adınızı Girmelisiniz !")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Şifrenizi Girmelisiniz !")]
        public string Password { get; set; }
    }
}
