using LibraryManagementSystem.Domain.Models;

namespace LibraryManagementSystem.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for book data access logic.
    /// </summary>
    public interface IBookDal
    {
        /// <summary>
        /// Get the top borrowed books.
        /// </summary>
        /// <param name="numberOfBooks">Number of top books to return.</param>
        /// <returns>A list of <see cref="TopBookDetail"/>s.</returns>
        Task<List<TopBookDetail>> GetTopBorrowedBooks(int numberOfBooks);

        /// <summary>
        /// Get the status of a book/>.
        /// </summary>
        /// <param name="bookId">Book id to get the status of.</param>
        /// <returns>A books <see cref="BookStatus"/></returns>
        Task<BookStatus> GetBookStatus(int bookId);

        /// <summary>
        /// Get the top borrowers.
        /// </summary>
        /// <param name="numberOfBorrowers">Number of top borrowers to return.</param>
        /// <param name="fromDate">The from date to lookup top borrowers.</param>
        /// <param name="toDate">The to date to lookup top borrowers.</param>
        /// <returns>A list of <see cref="TopBorrowerDetail"/>s.</returns>
        Task<List<TopBorrowerDetail>> GetTopBorrowers(int numberOfBorrowers, DateTime fromDate, DateTime toDate);
    }
}