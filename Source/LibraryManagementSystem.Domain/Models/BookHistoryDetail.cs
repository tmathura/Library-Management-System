namespace LibraryManagementSystem.Domain.Models
{
    public class BookHistoryDetail
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int DaysLoaned { get; set; }
    }
}