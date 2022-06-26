using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LibraryManagementSystem.GrpcServer.IntegrationTests.Common.Helpers;
using Xunit.Abstractions;

namespace LibraryManagementSystem.GrpcServer.IntegrationTests.Services
{
    [Collection(nameof(CommonHelper))]
    public class BooksServiceTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly CommonHelper _commonHelper;

        public BooksServiceTest(ITestOutputHelper outputHelper, CommonHelper commonHelper)
        {
            _outputHelper = outputHelper;
            _commonHelper = commonHelper;
        }

        /// <summary>
        /// Test the top {x} amount of books is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BooksServiceTestMemberData.TopBorrowedBooksData), MemberType = typeof(BooksServiceTestMemberData))]
        public async Task GetTopBorrowedBooks(int numberOfTopBooks, List<int> topBorrowedBooksData)
        {
            // Arrange
            var getTopBorrowedBooksResponses = new List<GetTopBorrowedBooksResponse>();

            // Act
            var getTopBorrowedBooksRequest = new GetTopBorrowedBooksRequest { NumberOfBooks = numberOfTopBooks };
            using var call = _commonHelper.BooksClient.GetTopBorrowedBooks(getTopBorrowedBooksRequest);
            while (await call.ResponseStream.MoveNext())
            {
                var current = call.ResponseStream.Current;
                getTopBorrowedBooksResponses.Add(current);
            }

            // Assert
            Assert.Equal(numberOfTopBooks, getTopBorrowedBooksResponses.Count);

            for (var i = 0; i < getTopBorrowedBooksResponses.Count; i++)
            {
                Assert.NotNull(getTopBorrowedBooksResponses[i].Result);
                Assert.Empty(getTopBorrowedBooksResponses[i].Errors);
                Assert.Equal(topBorrowedBooksData[i], getTopBorrowedBooksResponses[i].Result.Book.Id);
                _outputHelper.WriteLine($"One of the top books is: {getTopBorrowedBooksResponses[i].Result.Book.Title}.");
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
            // Act
            var getBookStatusRequest = new GetBookStatusRequest { BookId = bookId };
            var getBookStatusResponse = await _commonHelper.BooksClient.GetBookStatusAsync(getBookStatusRequest);

            // Assert
            Assert.NotNull(getBookStatusResponse.Result);
            Assert.Empty(getBookStatusResponse.Errors);
            Assert.Equal(numberAvailable, getBookStatusResponse.Result.Available);
            Assert.Equal(numberBorrowed, getBookStatusResponse.Result.Borrowed);
            Assert.Equal(numberLost, getBookStatusResponse.Result.Lost);

            _outputHelper.WriteLine($"Number of available books are: {getBookStatusResponse.Result.Available}.");
            _outputHelper.WriteLine($"Number of borrowed books are: {getBookStatusResponse.Result.Borrowed}.");
            _outputHelper.WriteLine($"Number of lost books are: {getBookStatusResponse.Result.Lost}.");
        }

        /// <summary>
        /// Test the top {x} borrows for a given time frame is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BooksServiceTestMemberData.TopBorrowersData), MemberType = typeof(BooksServiceTestMemberData))]
        public async Task GetTopBorrowers(int numberOfTopBorrowers, int expectedNumberOfBorrowers, List<int> topBorrowersData, DateTime fromDate, DateTime toDate)
        {
            // Arrange
            var getTopBorrowersResponses = new List<GetTopBorrowersResponse>();

            // Act
            var getTopBorrowersRequest = new GetTopBorrowersRequest { NumberOfBorrowers = numberOfTopBorrowers, FromDate = Timestamp.FromDateTime(DateTime.SpecifyKind(fromDate, DateTimeKind.Utc)), ToDate = Timestamp.FromDateTime(DateTime.SpecifyKind(toDate, DateTimeKind.Utc)) };
            using var call = _commonHelper.BooksClient.GetTopBorrowers(getTopBorrowersRequest);
            while (await call.ResponseStream.MoveNext())
            {
                var current = call.ResponseStream.Current;
                getTopBorrowersResponses.Add(current);
            }

            // Assert
            Assert.Equal(expectedNumberOfBorrowers, getTopBorrowersResponses.Count);

            for (var i = 0; i < getTopBorrowersResponses.Count; i++)
            {
                Assert.NotNull(getTopBorrowersResponses[i].Result);
                Assert.Empty(getTopBorrowersResponses[i].Errors);
                Assert.Equal(topBorrowersData[i], getTopBorrowersResponses[i].Result.Borrower.Id);
                _outputHelper.WriteLine($"One of the top borrowers are: {getTopBorrowersResponses[i].Result.Borrower.FirstName} {getTopBorrowersResponses[i].Result.Borrower.LastName}.");
            }
        }

        /// <summary>
        /// Test the borrowers borrowed book count for each time frame is equal to what is in the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BooksServiceTestMemberData.BorrowerBorrowedTimeFrameCountData), MemberType = typeof(BooksServiceTestMemberData))]
        public async Task GetBorrowersBorrowedBookCountForEachTimeFrame(int borrowerId, List<DateTime> fromDateTimeFrameData, List<DateTime> toDateTimeFrameData, List<int> booksLoaned)
        {
            // Arrange
            var getBorrowersBorrowedBookCountForEachTimeFrameResponses = new List<GetBorrowersBorrowedBookCountForEachTimeFrameResponse>();
            
            // Act
            var getBorrowersBorrowedBookCountForEachTimeFrameRequest = new GetBorrowersBorrowedBookCountForEachTimeFrameRequest { BorrowId = borrowerId };
            using var call = _commonHelper.BooksClient.GetBorrowersBorrowedBookCountForEachTimeFrame(getBorrowersBorrowedBookCountForEachTimeFrameRequest);
            while (await call.ResponseStream.MoveNext())
            {
                var current = call.ResponseStream.Current;
                getBorrowersBorrowedBookCountForEachTimeFrameResponses.Add(current);
            }

            // Assert
            for (var i = 0; i < getBorrowersBorrowedBookCountForEachTimeFrameResponses.Count; i++)
            {
                Assert.NotNull(getBorrowersBorrowedBookCountForEachTimeFrameResponses[i].Result);
                Assert.Empty(getBorrowersBorrowedBookCountForEachTimeFrameResponses[i].Errors);
                Assert.Equal(fromDateTimeFrameData[i], getBorrowersBorrowedBookCountForEachTimeFrameResponses[i].Result.FromDate.ToDateTime());
                Assert.Equal(toDateTimeFrameData[i], getBorrowersBorrowedBookCountForEachTimeFrameResponses[i].Result.ToDate.ToDateTime());
                Assert.Equal(booksLoaned[i], getBorrowersBorrowedBookCountForEachTimeFrameResponses[i].Result.BooksLoaned);
            }
        }

        /// <summary>
        /// Test that the other books loaned by borrowers of a specific book matched the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BooksServiceTestMemberData.OtherBorrowedBooksData), MemberType = typeof(BooksServiceTestMemberData))]
        public async Task GetOtherBooksLoanedByBorrowersOfASpecificBook(int bookId, int expectedBooks, List<int> otherBorrowedBooksData)
        {
            // Arrange
            var getOtherBooksLoanedByBorrowersOfASpecificBookResponses = new List<GetOtherBooksLoanedByBorrowersOfASpecificBookResponse>();
            
            // Act
            var getOtherBooksLoanedByBorrowersOfASpecificBookRequest = new GetOtherBooksLoanedByBorrowersOfASpecificBookRequest { BookId = bookId };
            using var call = _commonHelper.BooksClient.GetOtherBooksLoanedByBorrowersOfASpecificBook(getOtherBooksLoanedByBorrowersOfASpecificBookRequest);
            while (await call.ResponseStream.MoveNext())
            {
                var current = call.ResponseStream.Current;
                getOtherBooksLoanedByBorrowersOfASpecificBookResponses.Add(current);
            }

            // Assert
            Assert.Equal(expectedBooks, getOtherBooksLoanedByBorrowersOfASpecificBookResponses.Count);

            for (var i = 0; i < getOtherBooksLoanedByBorrowersOfASpecificBookResponses.Count; i++)
            {
                Assert.NotNull(getOtherBooksLoanedByBorrowersOfASpecificBookResponses[i].Result);
                Assert.Empty(getOtherBooksLoanedByBorrowersOfASpecificBookResponses[i].Errors);
                Assert.Equal(otherBorrowedBooksData[i], getOtherBooksLoanedByBorrowersOfASpecificBookResponses[i].Result.Id);
                _outputHelper.WriteLine($"One of the other books are: {getOtherBooksLoanedByBorrowersOfASpecificBookResponses[i].Result.Title}.");
            }
        }

        /// <summary>
        /// Test the books get and check that it is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BooksServiceTestMemberData.GetAllBooksData), MemberType = typeof(BooksServiceTestMemberData))]
        public async Task GetAllBooks(List<int> booksReturned)
        {
            // Arrange
            var getAllBooksResponses = new List<GetAllBooksResponse>();
            
            // Act
            using var call = _commonHelper.BooksClient.GetAllBooks(new Empty());
            while (await call.ResponseStream.MoveNext())
            {
                var current = call.ResponseStream.Current;
                getAllBooksResponses.Add(current);
            }

            // Assert
            Assert.Equal(booksReturned.Count, getAllBooksResponses.Count);

            for (var i = 0; i < getAllBooksResponses.Count; i++)
            {
                Assert.NotNull(getAllBooksResponses[i].Result);
                Assert.Empty(getAllBooksResponses[i].Errors);
                Assert.Equal(booksReturned[i], getAllBooksResponses[i].Result.Id);
                _outputHelper.WriteLine($"There is a book called: {getAllBooksResponses[i].Result.Title}.");
            }
        }

        /// <summary>
        /// Test the books get by id and check that it is equal to the expected data.
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(13)]
        public async Task GetBookById(int bookId)
        {
            // Act
            var getBookByIdRequest = new GetBookByIdRequest { BookId = bookId };
            var getBookByIdResponse = await _commonHelper.BooksClient.GetBookByIdAsync(getBookByIdRequest);

            // Assert
            Assert.NotNull(getBookByIdResponse.Result);
            Assert.Empty(getBookByIdResponse.Errors);
            Assert.Equal(bookId, getBookByIdResponse.Result.Id);
            _outputHelper.WriteLine($"There is a book called: {getBookByIdResponse.Result.Title}.");
        }

        /// <summary>
        /// Test a book loan history is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BooksServiceTestMemberData.GetBookHistoryDetailData), MemberType = typeof(BooksServiceTestMemberData))]
        public async Task GetBookHistory(int bookId, List<DateTime> bookHistoryDetailFromDate, List<DateTime> bookHistoryDetailToDate, List<DateTime> bookHistoryDetailReturnDate, List<int> bookHistoryDetailDaysLoaned)
        {
            // Act
            var getBookHistoryRequest = new GetBookHistoryRequest { BookId = bookId };
            var getBookHistoryResponse = await _commonHelper.BooksClient.GetBookHistoryAsync(getBookHistoryRequest);

            // Assert
            if (bookHistoryDetailFromDate.Count == 0)
            {
                Assert.Null(getBookHistoryResponse.Result);
            }
            else
            {
                Assert.Equal(bookHistoryDetailFromDate.Count, getBookHistoryResponse?.Result.BookHistoryDetails!.Count);

                for (var i = 0; i < getBookHistoryResponse?.Result.BookHistoryDetails!.Count; i++)
                {
                    Assert.Equal(bookHistoryDetailFromDate[i], getBookHistoryResponse!.Result.BookHistoryDetails![i].FromDate.ToDateTime());
                    Assert.Equal(bookHistoryDetailToDate[i], getBookHistoryResponse.Result.BookHistoryDetails[i].ToDate.ToDateTime());
                    Assert.Equal(bookHistoryDetailReturnDate[i], getBookHistoryResponse.Result.BookHistoryDetails[i].ReturnDate.ToDateTime());
                    Assert.Equal(bookHistoryDetailDaysLoaned[i], getBookHistoryResponse.Result.BookHistoryDetails[i].DaysLoaned);
                    _outputHelper.WriteLine($"Book '{getBookHistoryResponse.Result.Book.Title}' was loaned for {getBookHistoryResponse.Result.BookHistoryDetails[i].DaysLoaned} day/s from {getBookHistoryResponse.Result.BookHistoryDetails[i].FromDate.ToDateTime()} to {getBookHistoryResponse.Result.BookHistoryDetails[i].ToDate.ToDateTime()} and returned on {getBookHistoryResponse.Result.BookHistoryDetails[i].ReturnDate.ToDateTime()}.");
                }
            }
        }

        /// <summary>
        /// Test getting the books average read rate is equal to the expected data.
        /// </summary>
        [Theory]
        [InlineData(13, 49)]
        public async Task GetBookAverageReadRate(int bookId, int expectedAverageReadRate)
        {
            // Act
            var getBookAverageReadRateRequest = new GetBookAverageReadRateRequest { BookId = bookId };
            var getBookAverageReadRateResponse = await _commonHelper.BooksClient.GetBookAverageReadRateAsync(getBookAverageReadRateRequest);

            // Assert
            Assert.NotNull(getBookAverageReadRateResponse.Result);
            Assert.Empty(getBookAverageReadRateResponse.Errors);
            Assert.Equal(expectedAverageReadRate, getBookAverageReadRateResponse.Result.BookAverageReadRate);
        }
    }
}