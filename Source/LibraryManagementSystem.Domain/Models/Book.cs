namespace LibraryManagementSystem.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public long ISBN { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int TotalPages { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PublisherId { get; set; }

    }
}