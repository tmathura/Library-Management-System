using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Infrastructure.Implementations;
using LibraryManagementSystem.Infrastructure.IntegrationTests.Common.Helpers;
using System.Data.SqlClient;
using Xunit.Abstractions;

namespace LibraryManagementSystem.Infrastructure.IntegrationTests.Implementations
{
    [Collection(nameof(CommonHelper))]
    public class BookDalTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly CommonHelper _commonHelper;

        public BookDalTest(ITestOutputHelper outputHelper, CommonHelper commonHelper)
        {
            _outputHelper = outputHelper;
            _commonHelper = commonHelper;
        }

        /// <summary>
        /// Get top {x} amount of <see cref="Book"/>s.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookDalTestMemberData.TopBorrowedBooksData), MemberType = typeof(BookDalTestMemberData))]
        public async Task GetTopBorrowedBooks(int numberOfTopBooks, List<string> topBorrowedBooksData)
        {
            // Arrange
            List<TopBookDetail> topBorrowedBooks;

            await using var sqlConnection = new SqlConnection(_commonHelper.Settings.Database.ConnectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            await CommonHelper.AddTestDataToDatabase(sqlCommand);

            // Act
            try
            {
                topBorrowedBooks = await BookDal.GetTopBorrowedBooks(sqlCommand, numberOfTopBooks);
            }
            finally
            {
                await sqlTransaction.RollbackAsync();
            }

            // Assert
            Assert.Equal(numberOfTopBooks, topBorrowedBooks.Count);

            for (var i = 0; i < topBorrowedBooksData.Count; i++)
            {
                Assert.Equal(topBorrowedBooksData[i], topBorrowedBooks[i].Title);
                _outputHelper.WriteLine($"One of the top books is: {topBorrowedBooks[i].Title}.");
            }
        }

        /// <summary>
        /// Get status (available, borrowed, lost) of <see cref="Book"/>s.
        /// </summary>
        [Theory]
        [InlineData(1, 5, 0, 0)]
        [InlineData(13, 4, 1, 0)]
        public async Task GetBookStatus(int bookId, int numberAvailable, int numberBorrowed, int numberLost)
        {
            // Arrange
            BookStatus bookStatus;

            await using var sqlConnection = new SqlConnection(_commonHelper.Settings.Database.ConnectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            await CommonHelper.AddTestDataToDatabase(sqlCommand);

            // Act
            try
            {
                bookStatus = await BookDal.GetBookStatus(sqlCommand, bookId);
            }
            finally
            {
                await sqlTransaction.RollbackAsync();
            }

            // Assert
            Assert.Equal(numberAvailable, bookStatus.Available);
            Assert.Equal(numberBorrowed, bookStatus.Borrowed);
            Assert.Equal(numberLost, bookStatus.Lost);

            _outputHelper.WriteLine($"Number of available books are: {bookStatus.Available}.");
            _outputHelper.WriteLine($"Number of borrowed books are: {bookStatus.Borrowed}.");
            _outputHelper.WriteLine($"Number of lost books are: {bookStatus.Lost}.");
        }

        /// <summary>
        /// Get top {x} amount of <see cref="Book"/>s.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookDalTestMemberData.TopBorrowersData), MemberType = typeof(BookDalTestMemberData))]
        public async Task GetTopBorrowers(int numberOfTopBorrowers, List<string> topBorrowersData)
        {
            // Arrange
            List<TopBorrowerDetail> topBorrowers;

            await using var sqlConnection = new SqlConnection(_commonHelper.Settings.Database.ConnectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            await CommonHelper.AddTestDataToDatabase(sqlCommand);

            // Act
            try
            {
                topBorrowers = await BookDal.GetTopBorrowers(sqlCommand, numberOfTopBorrowers);
            }
            finally
            {
                await sqlTransaction.RollbackAsync();
            }

            // Assert
            Assert.Equal(numberOfTopBorrowers, topBorrowers.Count);
            
            for (var i = 0; i < topBorrowersData.Count; i++)
            {
                Assert.Equal(topBorrowersData[i], $"{topBorrowers[i].FirstName} {topBorrowers[i].LastName}");
                _outputHelper.WriteLine($"One of the top borrowers are: {topBorrowers[i].FirstName} {topBorrowers[i].LastName}.");
            }
        }
    }
}