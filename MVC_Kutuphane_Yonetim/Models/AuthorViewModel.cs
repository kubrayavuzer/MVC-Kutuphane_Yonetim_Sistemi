namespace MVC_Kutuphane_Yonetim.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }
        public string Edit { get; set; }
        public string Create { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDone { get; set; }
        public int BookId { get; set; }
    }
}
