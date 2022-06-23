namespace LibraryManagementSystem.Domain.Models
{
    public class BorrowerBorrowedTimeFrameCount
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BooksLoaned { get; set; }

    }
}