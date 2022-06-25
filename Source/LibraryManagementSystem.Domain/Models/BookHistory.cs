namespace LibraryManagementSystem.Domain.Models
{
    public class BookHistory : Book
    {
        public BookHistory(List<BookHistoryDetail> bookHistoryDetails)
        {
            BookHistoryDetails = bookHistoryDetails;
        }

        public List<BookHistoryDetail> BookHistoryDetails { get; }
    }
}