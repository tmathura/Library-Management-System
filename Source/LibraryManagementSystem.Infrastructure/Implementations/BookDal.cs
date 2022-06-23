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

        public async Task<List<TopBookDetail>> GetTopBorrowedBooks(SqlCommand sqlCommand, int numberOfBooks)
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

    }
}