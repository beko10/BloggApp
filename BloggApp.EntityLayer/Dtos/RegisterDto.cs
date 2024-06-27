using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.EntityLayer.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez...")]
        [Display(Name = "Kullanıcı Adı : ")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email Formatı Yanlış")]
        [Required(ErrorMessage = "Email Boş Geçilemez...")]
        [Display(Name = "Email : ")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Telefon Boş Geçilemez...")]
        [Display(Name = "Telefon  : ")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Boş Geçilemez...")]
        [Display(Name = "Şifre : ")]
        [MinLength(6, ErrorMessage = "Şifreniz en aza 6 karakter olabilir")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmuyor")]
        [Required(ErrorMessage = "Şifre Onay Geçilemez...")]
        [Display(Name = "Şifre Onay : ")]
        [MinLength(6, ErrorMessage = "Şifreniz en aza 6 karakter olabilir")]
        public string PasswordConfirm { get; set; }
    }
}
