using Microsoft.AspNetCore.Mvc;

namespace MVC_Kutuphane_Yonetim.Models
{
    public class BookListViewModel : Controller
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Edit { get; set; }
        public string Create {  get; set; }
        public bool IsDone { get; set; }
    }
}
