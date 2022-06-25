namespace LibraryManagementSystem.Domain.Models
{
    public class BookHistory : Book
    {
        public List<BookHistoryDetail>? BookHistoryDetails { get; set; }
    }
}