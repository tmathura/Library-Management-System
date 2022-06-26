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
        /// Test the top {x} amount of books is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookDalTestMemberData.TopBorrowedBooksData), MemberType = typeof(BookDalTestMemberData))]
        public async Task GetTopBorrowedBooks(int numberOfTopBooks, List<int> topBorrowedBooksData)
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

            for (var i = 0; i < topBorrowedBooks.Count; i++)
            {
                Assert.Equal(topBorrowedBooksData[i], topBorrowedBooks[i].Id);
                _outputHelper.WriteLine($"One of the top books is: {topBorrowedBooks[i].Title}.");
            }
        }

        /// <summary>
        /// Verify the status (available, borrowed, lost) of a book is equal to the expected member data.
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
        /// Test the top {x} borrows for a given time frame is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookDalTestMemberData.TopBorrowersData), MemberType = typeof(BookDalTestMemberData))]
        public async Task GetTopBorrowers(int numberOfTopBorrowers, int expectedNumberOfBorrowers, List<int> topBorrowersData, DateTime fromDate, DateTime toDate)
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
                topBorrowers = await BookDal.GetTopBorrowers(sqlCommand, numberOfTopBorrowers, fromDate, toDate);
            }
            finally
            {
                await sqlTransaction.RollbackAsync();
            }

            // Assert
            Assert.Equal(expectedNumberOfBorrowers, topBorrowers.Count);

            for (var i = 0; i < topBorrowers.Count; i++)
            {
                Assert.Equal(topBorrowersData[i], topBorrowers[i].Id);
                _outputHelper.WriteLine($"One of the top borrowers are: {topBorrowers[i].FirstName} {topBorrowers[i].LastName}.");
            }
        }

        /// <summary>
        /// Test the borrowers borrowed book count for each time frame is equal to what is in the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookDalTestMemberData.BorrowerBorrowedTimeFrameCountData), MemberType = typeof(BookDalTestMemberData))]
        public async Task GetBorrowersBorrowedBookCountForEachTimeFrame(int borrowerId, List<DateTime> fromDateTimeFrameData, List<DateTime> toDateTimeFrameData, List<int> booksLoaned)
        {
            // Arrange
            List<BorrowerBorrowedTimeFrameCount> borrowerBorrowedTimeFrameCount;

            await using var sqlConnection = new SqlConnection(_commonHelper.Settings.Database.ConnectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            await CommonHelper.AddTestDataToDatabase(sqlCommand);

            // Act
            try
            {
                borrowerBorrowedTimeFrameCount = await BookDal.GetBorrowersBorrowedBookCountForEachTimeFrame(sqlCommand, borrowerId);
            }
            finally
            {
                await sqlTransaction.RollbackAsync();
            }

            // Assert
            for (var i = 0; i < borrowerBorrowedTimeFrameCount.Count; i++)
            {
                Assert.Equal(fromDateTimeFrameData[i], borrowerBorrowedTimeFrameCount[i].FromDate);
                Assert.Equal(toDateTimeFrameData[i], borrowerBorrowedTimeFrameCount[i].ToDate);
                Assert.Equal(booksLoaned[i], borrowerBorrowedTimeFrameCount[i].BooksLoaned);
            }
        }

        /// <summary>
        /// Test that the other books loaned by borrowers of a specific book matched the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookDalTestMemberData.OtherBorrowedBooksData), MemberType = typeof(BookDalTestMemberData))]
        public async Task GetOtherBooksLoanedByBorrowersOfASpecificBook(int bookId, int expectedBooks, List<int> otherBorrowedBooksData)
        {
            // Arrange
            List<Book> books;

            await using var sqlConnection = new SqlConnection(_commonHelper.Settings.Database.ConnectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            await CommonHelper.AddTestDataToDatabase(sqlCommand);

            // Act
            try
            {
                books = await BookDal.GetOtherBooksLoanedByBorrowersOfASpecificBook(sqlCommand, bookId);
            }
            finally
            {
                await sqlTransaction.RollbackAsync();
            }

            // Assert
            Assert.Equal(expectedBooks, books.Count);

            for (var i = 0; i < books.Count; i++)
            {
                Assert.Equal(otherBorrowedBooksData[i], books[i].Id);
                _outputHelper.WriteLine($"One of the other books are: {books[i].Title}.");
            }
        }

        /// <summary>
        /// Test the books get and check that it is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookDalTestMemberData.GetBooksData), MemberType = typeof(BookDalTestMemberData))]
        public async Task GetBooks(int? bookId, List<int> booksReturned)
        {
            // Arrange
            List<Book> books;

            await using var sqlConnection = new SqlConnection(_commonHelper.Settings.Database.ConnectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            await CommonHelper.AddTestDataToDatabase(sqlCommand);

            // Act
            try
            {
                books = await BookDal.GetBooks(sqlCommand, bookId);
            }
            finally
            {
                await sqlTransaction.RollbackAsync();
            }

            // Assert
            Assert.Equal(booksReturned.Count, books.Count);

            for (var i = 0; i < books.Count; i++)
            {
                Assert.Equal(booksReturned[i], books[i].Id);
                _outputHelper.WriteLine($"There is a book called: {books[i].Title}.");
            }
        }

        /// <summary>
        /// Test a book loan history is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookDalTestMemberData.GetBookHistoryDetailData), MemberType = typeof(BookDalTestMemberData))]
        public async Task GetBookHistory(int bookId, List<DateTime> bookHistoryDetailFromDate, List<DateTime> bookHistoryDetailToDate, List<DateTime> bookHistoryDetailReturnDate, List<int> bookHistoryDetailDaysLoaned)
        {
            // Arrange
            BookHistory? bookHistory;

            await using var sqlConnection = new SqlConnection(_commonHelper.Settings.Database.ConnectionString);
            await sqlConnection.OpenAsync();
            var sqlCommand = sqlConnection.CreateCommand();
            var sqlTransaction = sqlConnection.BeginTransaction();
            sqlCommand.Transaction = sqlTransaction;

            await CommonHelper.AddTestDataToDatabase(sqlCommand);

            // Act
            try
            {
                bookHistory = await BookDal.GetBookHistory(sqlCommand, bookId);
            }
            finally
            {
                await sqlTransaction.RollbackAsync();
            }

            // Assert
            if (bookHistoryDetailFromDate.Count == 0)
            {
                Assert.Null(bookHistory);
            }
            else
            {
                Assert.Equal(bookHistoryDetailFromDate.Count, bookHistory?.BookHistoryDetails!.Count);

                for (var i = 0; i < bookHistory?.BookHistoryDetails!.Count; i++)
                {
                    Assert.Equal(bookHistoryDetailFromDate[i], bookHistory!.BookHistoryDetails![i].FromDate);
                    Assert.Equal(bookHistoryDetailToDate[i], bookHistory.BookHistoryDetails[i].ToDate);
                    Assert.Equal(bookHistoryDetailReturnDate[i], bookHistory.BookHistoryDetails[i].ReturnDate);
                    Assert.Equal(bookHistoryDetailDaysLoaned[i], bookHistory.BookHistoryDetails[i].DaysLoaned);
                    _outputHelper.WriteLine($"Book '{bookHistory.Title}' was loaned for {bookHistory.BookHistoryDetails[i].DaysLoaned} day/s from {bookHistory.BookHistoryDetails[i].FromDate} to {bookHistory.BookHistoryDetails[i].ToDate} and returned on {bookHistory.BookHistoryDetails[i].ReturnDate}.");
                }
            }
        }
    }
}