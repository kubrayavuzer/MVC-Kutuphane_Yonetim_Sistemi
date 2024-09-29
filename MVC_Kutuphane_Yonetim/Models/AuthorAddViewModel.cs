using System.ComponentModel.DataAnnotations;

namespace MVC_Kutuphane_Yonetim.Models
{
    public class AuthorAddViewModel
    {
        [Required(ErrorMessage = "İsim bilgisini doldurmak zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim bilgisini doldurmak zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Detay bilgisini doldurmak zorunludur.")]
        [MinLength(30, ErrorMessage = "Detay en az 30 karakter olmak zorundadır.")]
        public string Details { get; set; }

    }
}
