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

        /// <summary>
        /// Get the borrowers borrowed book count for each time frame.
        /// </summary>
        /// <param name="borrowId">Borrow id to lookup.</param>
        /// <returns>A list of <see cref="BorrowerBorrowedTimeFrameCount"/>s.</returns>
        Task<List<BorrowerBorrowedTimeFrameCount>> GetBorrowersBorrowedBookCountForEachTimeFrame(int borrowId);

        /// <summary>
        /// Get other books loaned by borrowers of a specific book.
        /// </summary>
        /// <param name="bookId">Borrow id to lookup.</param>
        /// <returns>A list of <see cref="Book"/>s.</returns>
        Task<List<Book>> GetOtherBooksLoanedByBorrowersOfASpecificBook(int bookId);

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns><see cref="Book"/>s</returns>
        Task<List<Book>> GetAllBooks();

        /// <summary>
        /// Get book by id.
        /// </summary>
        /// <param name="bookId">Id of book to lookup.</param>
        /// <returns><see cref="Book"/></returns>
        Task<Book> GetBookById(int bookId);

        /// <summary>
        /// Get the loan history of a book.
        /// </summary>
        /// <param name="bookId">Book id to get the loan history of.</param>
        /// <returns>A books <see cref="BookHistory"/></returns>
        Task<BookHistory?> GetBookHistory(int bookId);
    }
}