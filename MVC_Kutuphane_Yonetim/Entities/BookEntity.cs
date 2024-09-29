namespace MVC_Kutuphane_Yonetim.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Edit {  get; set; }
        public string Create {  get; set; }

        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public int CopiesAvailable { get; set; }
        public int NumberOfPages { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDone { get; set; }
    }
}
