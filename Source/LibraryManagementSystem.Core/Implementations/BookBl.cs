using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Infrastructure.Interfaces;

namespace LibraryManagementSystem.Core.Implementations
{
    /// <summary>
    /// Book business access logic
    /// </summary>
    /// <seealso cref="IBookBl" />
    public class BookBl : IBookBl
    {
        private readonly IBookDal _bookDal;

        public BookBl(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        /// <summary>
        /// Get the top borrowed books.
        /// </summary>
        /// <param name="numberOfBooks">Number of top books to return.</param>
        /// <returns>A list of <see cref="TopBookDetail"/>s.</returns>
        public async Task<List<TopBookDetail>> GetTopBorrowedBooks(int numberOfBooks)
        {
            var books = await _bookDal.GetTopBorrowedBooks(numberOfBooks);

            return books;
        }

        /// <summary>
        /// Get the status of a book/>.
        /// </summary>
        /// <param name="bookId">Book id to get the status of.</param>
        /// <returns>A books <see cref="BookStatus"/></returns>
        public async Task<BookStatus?> GetBookStatus(int bookId)
        {
            var bookStatus = await _bookDal.GetBookStatus(bookId);

            return bookStatus;
        }

        /// <summary>
        /// Get the top borrowers.
        /// </summary>
        /// <param name="numberOfBorrowers">Number of top borrowers to return.</param>
        /// <param name="fromDate">The from date to lookup top borrowers.</param>
        /// <param name="toDate">The to date to lookup top borrowers.</param>
        /// <returns>A list of <see cref="TopBorrowerDetail"/>s.</returns>
        public async Task<List<TopBorrowerDetail>> GetTopBorrowers(int numberOfBorrowers, DateTime fromDate, DateTime toDate)
        {
            var borrowers = await _bookDal.GetTopBorrowers(numberOfBorrowers, fromDate, toDate);

            return borrowers;
        }

        /// <summary>
        /// Get the borrowers borrowed book count for each time frame.
        /// </summary>
        /// <param name="borrowId">Borrow id to lookup.</param>
        /// <returns>A list of <see cref="BorrowerBorrowedTimeFrameCount"/>s.</returns>
        public async Task<List<BorrowerBorrowedTimeFrameCount>> GetBorrowersBorrowedBookCountForEachTimeFrame(int borrowId)
        {
            var borrowerBorrowedTimeFrameCount = await _bookDal.GetBorrowersBorrowedBookCountForEachTimeFrame(borrowId);

            return borrowerBorrowedTimeFrameCount;
        }

        /// <summary>
        /// Get other books loaned by borrowers of a specific book.
        /// </summary>
        /// <param name="bookId">Borrow id to lookup.</param>
        /// <returns>A list of <see cref="Book"/>s.</returns>
        public async Task<List<Book>> GetOtherBooksLoanedByBorrowersOfASpecificBook(int bookId)
        {
            var books = await _bookDal.GetOtherBooksLoanedByBorrowersOfASpecificBook(bookId);

            return books;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>A list of <see cref="Book"/>s.</returns>
        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _bookDal.GetAllBooks();

            return books;
        }

        /// <summary>
        /// Get book by id.
        /// </summary>
        /// <param name="bookId">Id of book to lookup.</param>
        /// <returns><see cref="Book"/></returns>
        public async Task<Book?> GetBookById(int bookId)
        {
            var book = await _bookDal.GetBookById(bookId);

            return book;
        }

        /// <summary>
        /// Get a book history.
        /// </summary>
        /// <param name="bookId">Id of book to lookup.</param>
        /// <returns><see cref="Book"/></returns>
        public async Task<BookHistory?> GetBookHistory(int bookId)
        {
            var bookHistory = await _bookDal.GetBookHistory(bookId);

            return bookHistory;
        }

        /// <summary>
        /// Get a book average read rate.
        /// </summary>
        /// <param name="bookId">Id of book to lookup.</param>
        /// <returns><see cref="Book"/></returns>
        public async Task<int> GetBookAverageReadRate(int bookId)
        {
            var bookHistory = await _bookDal.GetBookHistory(bookId);

            if (bookHistory == null)
            {
                return 0;
            }

            var averagePageReadRatePerPeriod = bookHistory.BookHistoryDetails!.Select(x => (int)Math.Round(bookHistory.TotalPages / (double)x.DaysLoaned, MidpointRounding.AwayFromZero)).ToList();
            var averageReadRate = (int)Math.Round((double)averagePageReadRatePerPeriod.Sum() / bookHistory.BookHistoryDetails!.Count, MidpointRounding.AwayFromZero);

            return averageReadRate;
        }
    }
}