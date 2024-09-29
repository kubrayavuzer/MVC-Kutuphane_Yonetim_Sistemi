using System.ComponentModel.DataAnnotations;

namespace MVC_Kutuphane_Yonetim.Models
{
    public class BookAddViewModel
    {
        [Required (ErrorMessage = "Başlık bilgisini doldurmak zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Detay bilgisini doldurmak zorunludur.")]
        [MinLength (30, ErrorMessage = "Detay en az 30 karakter olmak zorundadır.")]
        public string Details { get; set; }

        public int NumberOfPages { get; set; }
        public int AuthorId { get; set; }
    }
}
