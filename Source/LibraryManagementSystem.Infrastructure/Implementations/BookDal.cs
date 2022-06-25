using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Infrastructure.Extensions;
using LibraryManagementSystem.Infrastructure.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Infrastructure.Implementations
{
    /// <summary>
    /// Book data access logic.
    /// </summary>
    /// <seealso cref="IBookDal" />
    public class BookDal : IBookDal
    {
        private readonly string _connectionString;
        public BookDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Get the top borrowed books.
        /// </summary>
        /// <param name="numberOfBooks">Number of top books to return.</param>
        /// <returns>A list of <see cref="TopBookDetail"/>s.</returns>
        public async Task<List<TopBookDetail>> GetTopBorrowedBooks(int numberOfBooks)
        {
            List<TopBookDetail> books;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                books = await GetTopBorrowedBooks(sqlCommand, numberOfBooks);

                await sqlTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                await sqlTransaction.RollbackAsync();

                throw;
            }

            return books;
        }

        /// <summary>
        /// Get the top borrowed books.
        /// </summary>
        /// <param name="sqlCommand">The SqlCommand to use when interacting with the database.</param>
        /// <param name="numberOfBooks">Number of top books to return.</param>
        /// <returns>A list of <see cref="TopBookDetail"/>s.</returns>
        public static async Task<List<TopBookDetail>> GetTopBorrowedBooks(SqlCommand sqlCommand, int numberOfBooks)
        {
            var books = new List<TopBookDetail>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[top_borrowed_books_get]";
            sqlCommand.Parameters.Clear();

            sqlCommand.Parameters.Add("@number_of_books", SqlDbType.Int).Value = numberOfBooks;

            await using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            while (await sqlDataReader.ReadAsync())
            {
                var book = new TopBookDetail
                {
                    CopiesLoaned = Convert.ToInt32(sqlDataReader["copies_loaned"]),
                    Id = Convert.ToInt32(sqlDataReader["id"]),
                    ISBN = Convert.ToInt64(sqlDataReader["isbn"]),
                    Title = Convert.ToString(sqlDataReader["title"]),
                    Description = Convert.ToString(sqlDataReader["description"]),
                    TotalPages = Convert.ToInt32(sqlDataReader["total_pages"]),
                    PublishedDate = Convert.ToDateTime(sqlDataReader["published_date"]),
                    PublisherId = Convert.ToInt32(sqlDataReader["publisher_id"])
                };

                books.Add(book);
            }

            return books;
        }

        /// <summary>
        /// Get the status of a book/>.
        /// </summary>
        /// <param name="bookId">Book id to get the status of.</param>
        /// <returns>A books <see cref="BookStatus"/></returns>
        public async Task<BookStatus> GetBookStatus(int bookId)
        {
            BookStatus bookStatus;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                bookStatus = await GetBookStatus(sqlCommand, bookId);

                await sqlTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                await sqlTransaction.RollbackAsync();

                throw;
            }

            return bookStatus;
        }

        /// <summary>
        /// Get the status of a book/>.
        /// </summary>
        /// <param name="sqlCommand">The SqlCommand to use when interacting with the database.</param>
        /// <param name="bookId">Book id to get the status of.</param>
        /// <returns>A books <see cref="BookStatus"/></returns>
        public static async Task<BookStatus> GetBookStatus(SqlCommand sqlCommand, int bookId)
        {
            var bookStatus = new BookStatus();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[book_status_get]";
            sqlCommand.Parameters.Clear();

            sqlCommand.Parameters.Add("@book_id", SqlDbType.Int).Value = bookId;

            await using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            while (await sqlDataReader.ReadAsync())
            {
                bookStatus.Available = Convert.ToInt32(sqlDataReader["available"]);
                bookStatus.Borrowed = Convert.ToInt32(sqlDataReader["borrowed"]);
                bookStatus.Lost = Convert.ToInt32(sqlDataReader["lost"]);
            }

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
            List<TopBorrowerDetail> borrowers;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                borrowers = await GetTopBorrowers(sqlCommand, numberOfBorrowers, fromDate, toDate);

                await sqlTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                await sqlTransaction.RollbackAsync();

                throw;
            }

            return borrowers;
        }

        /// <summary>
        /// Get the top borrowers.
        /// </summary>
        /// <param name="sqlCommand">The SqlCommand to use when interacting with the database.</param>
        /// <param name="numberOfBorrowers">Number of top borrowers to return.</param>
        /// <param name="fromDate">The from date to lookup top borrowers.</param>
        /// <param name="toDate">The to date to lookup top borrowers.</param>
        /// <returns>A list of <see cref="TopBorrowerDetail"/>s.</returns>
        public static async Task<List<TopBorrowerDetail>> GetTopBorrowers(SqlCommand sqlCommand, int numberOfBorrowers, DateTime fromDate, DateTime toDate)
        {
            var borrowers = new List<TopBorrowerDetail>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[top_borrowers_get]";
            sqlCommand.Parameters.Clear();

            sqlCommand.Parameters.Add("@number_of_borrowers", SqlDbType.Int).Value = numberOfBorrowers;
            sqlCommand.Parameters.Add("@from_date", SqlDbType.Date).Value = fromDate;
            sqlCommand.Parameters.Add("@to_date", SqlDbType.Date).Value = toDate;

            await using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            while (await sqlDataReader.ReadAsync())
            {
                var book = new TopBorrowerDetail
                {
                    BooksLoaned = Convert.ToInt32(sqlDataReader["books_loaned"]),
                    Id = Convert.ToInt32(sqlDataReader["id"]),
                    FirstName = Convert.ToString(sqlDataReader["first_name"]),
                    LastName = Convert.ToString(sqlDataReader["last_name"]),
                    ContactNumber = Convert.ToString(sqlDataReader["contact_number"]),
                    Address = Convert.ToString(sqlDataReader["address"])
                };

                borrowers.Add(book);
            }

            return borrowers;
        }

        /// <summary>
        /// Get the borrowers borrowed book count for each time frame.
        /// </summary>
        /// <param name="borrowId">Borrow id to lookup.</param>
        /// <returns>A list of <see cref="BorrowerBorrowedTimeFrameCount"/>s.</returns>
        public async Task<List<BorrowerBorrowedTimeFrameCount>> GetBorrowersBorrowedBookCountForEachTimeFrame(int borrowId)
        {
            List<BorrowerBorrowedTimeFrameCount> borrowerBorrowedTimeFrameCount;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                borrowerBorrowedTimeFrameCount = await GetBorrowersBorrowedBookCountForEachTimeFrame(sqlCommand, borrowId);

                await sqlTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                await sqlTransaction.RollbackAsync();

                throw;
            }

            return borrowerBorrowedTimeFrameCount;
        }

        /// <summary>
        /// Get the borrowers borrowed book count for each time frame.
        /// </summary>
        /// <param name="sqlCommand">The SqlCommand to use when interacting with the database.</param>
        /// <param name="borrowId">Borrow id to lookup.</param>
        /// <returns>A list of <see cref="BorrowerBorrowedTimeFrameCount"/>s.</returns>
        public static async Task<List<BorrowerBorrowedTimeFrameCount>> GetBorrowersBorrowedBookCountForEachTimeFrame(SqlCommand sqlCommand, int borrowId)
        {
            var borrowerBorrowedTimeFrameCount = new List<BorrowerBorrowedTimeFrameCount>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[borrowers_borrowed_book_count_for_each_time_frame_get]";
            sqlCommand.Parameters.Clear();

            sqlCommand.Parameters.Add("@borrower_id", SqlDbType.Int).Value = borrowId;

            await using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            while (await sqlDataReader.ReadAsync())
            {
                var book = new BorrowerBorrowedTimeFrameCount
                {
                    FromDate = Convert.ToDateTime(sqlDataReader["from_date"]),
                    ToDate = Convert.ToDateTime(sqlDataReader["to_date"]),
                    BooksLoaned = Convert.ToInt32(sqlDataReader["books_loaned"])
                };

                borrowerBorrowedTimeFrameCount.Add(book);
            }

            return borrowerBorrowedTimeFrameCount;
        }

        /// <summary>
        /// Get other books loaned by borrowers of a specific book.
        /// </summary>
        /// <param name="bookId">Borrow id to lookup.</param>
        /// <returns>A list of <see cref="Book"/>s.</returns>
        public async Task<List<Book>> GetOtherBooksLoanedByBorrowersOfASpecificBook(int bookId)
        {
            List<Book> books;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                books = await GetOtherBooksLoanedByBorrowersOfASpecificBook(sqlCommand, bookId);

                await sqlTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                await sqlTransaction.RollbackAsync();

                throw;
            }

            return books;
        }

        /// <summary>
        /// Get other books loaned by borrowers of a specific book.
        /// </summary>
        /// <param name="sqlCommand">The SqlCommand to use when interacting with the database.</param>
        /// <param name="bookId">Borrow id to lookup.</param>
        /// <returns>A list of <see cref="Book"/>s.</returns>
        public static async Task<List<Book>> GetOtherBooksLoanedByBorrowersOfASpecificBook(SqlCommand sqlCommand, int bookId)
        {
            var books = new List<Book>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[other_books_loaned_by_borrowers_of_a_specific_book_get]";
            sqlCommand.Parameters.Clear();

            sqlCommand.Parameters.Add("@book_id", SqlDbType.Int).Value = bookId;

            await using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            while (await sqlDataReader.ReadAsync())
            {
                var book = new Book
                {
                    Id = Convert.ToInt32(sqlDataReader["id"]),
                    ISBN = Convert.ToInt64(sqlDataReader["isbn"]),
                    Title = Convert.ToString(sqlDataReader["title"]),
                    Description = Convert.ToString(sqlDataReader["description"]),
                    TotalPages = Convert.ToInt32(sqlDataReader["total_pages"]),
                    PublishedDate = Convert.ToDateTime(sqlDataReader["published_date"]),
                    PublisherId = Convert.ToInt32(sqlDataReader["publisher_id"])
                };

                books.Add(book);
            }

            return books;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>A list of <see cref="Book"/>s.</returns>
        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> books;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                books = await GetBooks(sqlCommand, null);

                await sqlTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                await sqlTransaction.RollbackAsync();
                throw;
            }

            return books;
        }

        /// <summary>
        /// Get book by id.
        /// </summary>
        /// <param name="bookId">Id of book to lookup.</param>
        /// <returns><see cref="Book"/></returns>
        public async Task<Book> GetBookById(int bookId)
        {
            Book book;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {

                var books = await GetBooks(sqlCommand, bookId);
                book = books.FirstOrDefault()!;

                await sqlTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                await sqlTransaction.RollbackAsync();
                throw;
            }

            return book;
        }

        /// <summary>
        /// Get books.
        /// </summary>
        /// <param name="sqlCommand">The SqlCommand to use when interacting with the database.</param>
        /// <param name="bookId">Id of book to lookup.</param>
        /// <returns>A list of <see cref="Book"/>s.</returns>
        public static async Task<List<Book>> GetBooks(SqlCommand sqlCommand, int? bookId)
        {
            var books = new List<Book>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[books_get]";
            sqlCommand.Parameters.Clear();

            sqlCommand.Parameters.Add("@book_id", SqlDbType.Int).Value = bookId.ToSqlNull();

            await using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            while (await sqlDataReader.ReadAsync())
            {
                var book = new Book
                {
                    Id = Convert.ToInt32(sqlDataReader["id"]),
                    ISBN = Convert.ToInt64(sqlDataReader["isbn"]),
                    Title = Convert.ToString(sqlDataReader["title"]),
                    Description = Convert.ToString(sqlDataReader["description"]),
                    TotalPages = Convert.ToInt32(sqlDataReader["total_pages"]),
                    PublishedDate = Convert.ToDateTime(sqlDataReader["published_date"]),
                    PublisherId = Convert.ToInt32(sqlDataReader["publisher_id"])
                };

                books.Add(book);
            }

            return books;
        }

        /// <summary>
        /// Get the loan history detail of a book.
        /// </summary>
        /// <param name="bookId">Book id to get the loan history of.</param>
        /// <returns>A list of <see cref="BookHistoryDetail"/>s.</returns>
        public async Task<List<BookHistoryDetail>> GetBookHistoryDetail(int bookId)
        {
            List<BookHistoryDetail> bookHistoryDetails;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                bookHistoryDetails = await GetBookHistoryDetail(sqlCommand, bookId);

                await sqlTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                await sqlTransaction.RollbackAsync();

                throw;
            }

            return bookHistoryDetails;
        }

        /// <summary>
        /// Get the loan history detail of a book.
        /// </summary>
        /// <param name="sqlCommand">The SqlCommand to use when interacting with the database.</param>
        /// <param name="bookId">Book id to get the loan history of.</param>
        /// <returns>A list of <see cref="BookHistoryDetail"/>s.</returns>
        public static async Task<List<BookHistoryDetail>> GetBookHistoryDetail(SqlCommand sqlCommand, int bookId)
        {
            var bookHistoryDetails = new List<BookHistoryDetail>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[book_loan_history_get]";
            sqlCommand.Parameters.Clear();

            sqlCommand.Parameters.Add("@book_id", SqlDbType.Int).Value = bookId;

            await using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
            while (await sqlDataReader.ReadAsync())
            {
                var bookHistoryDetail = new BookHistoryDetail
                {
                    FromDate = Convert.ToDateTime(sqlDataReader["from_date"]),
                    ToDate = Convert.ToDateTime(sqlDataReader["to_date"]),
                    ReturnDate = Convert.ToDateTime(sqlDataReader["return_date"]),
                    DaysLoaned = Convert.ToInt32(sqlDataReader["days_loaned"])
                };

                bookHistoryDetails.Add(bookHistoryDetail);
            }

            return bookHistoryDetails;
        }
    }
}