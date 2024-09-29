namespace MVC_Kutuphane_Yonetim.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }
        public string Edit {  get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDone { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int Age { get; set; }
    }
}
