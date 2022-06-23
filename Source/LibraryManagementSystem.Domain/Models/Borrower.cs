namespace LibraryManagementSystem.Domain.Models
{
    public class Borrower
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }

    }
}