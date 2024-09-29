using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Kutuphane_Yonetim.Models
{
    public class SignUpViewModel 
    {

        [Required(ErrorMessage = "Email bilgisini doldurmak zorunludur.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre bilgisini doldurmak zorunludur.")]
        public string Password { get; set; }

        [Compare(nameof(Password))] 
        public string PasswordConfirm { get; set; }
    }
}
