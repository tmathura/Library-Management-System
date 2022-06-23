namespace LibraryManagementSystem.Domain.Models
{
    public class BookStatus
    {
        public int Available { get; set; }
        public int Borrowed { get; set; }
        public int Lost { get; set; }

    }
}