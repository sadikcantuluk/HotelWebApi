using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Ad alanı gereklidir !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir !")]
        public string SurnameName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı gereklidir !")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email alanı gereklidir !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şehir alanı gereklidir !")]
        public string City { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir !")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Doğrulama alanı gereklidir !")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmalıdır !")]
        public string ConfirmPassword { get; set; }
    }
}
