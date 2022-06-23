using LibraryManagementSystem.Domain.Models;

namespace LibraryManagementSystem.Infrastructure.Interfaces;

public interface IBookDal
{
    Task<List<TopBookDetail>> GetTopBorrowedBooks(int numberOfBooks);
    Task<BookStatus> GetBookStatus(int bookId);
}