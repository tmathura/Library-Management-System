using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Infrastructure.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Infrastructure.Implementations
{
    public class BookDal : IBookDal
    {
        private readonly string _connectionString;
        public BookDal(string connectionString)
        {
            _connectionString = connectionString;
        }

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

        public async Task<List<TopBorrowerDetail>> GetTopBorrowers(int numberOfBorrowers)
        {
            List<TopBorrowerDetail> borrowers;

            await using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            try
            {
                borrowers = await GetTopBorrowers(sqlCommand, numberOfBorrowers);

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

        public static async Task<List<TopBorrowerDetail>> GetTopBorrowers(SqlCommand sqlCommand, int numberOfBorrows)
        {
            var borrowers = new List<TopBorrowerDetail>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[top_borrowers_get]";
            sqlCommand.Parameters.Clear();

            sqlCommand.Parameters.Add("@number_of_borrowers", SqlDbType.Int).Value = numberOfBorrows;

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

    }
}