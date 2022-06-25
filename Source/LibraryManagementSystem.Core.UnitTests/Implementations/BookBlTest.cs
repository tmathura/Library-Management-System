using LibraryManagementSystem.Core.Implementations;
using LibraryManagementSystem.Domain.Models;
using LibraryManagementSystem.Infrastructure.Interfaces;
using Moq;

namespace LibraryManagementSystem.Core.UnitTests.Implementations
{
    public class BookBlTest
    {
        private readonly Mock<IBookDal> _mockIBookDal;
        private BookBl _bookBl;

        public BookBlTest()
        {
            _mockIBookDal = new Mock<IBookDal>();
        }

        /// <summary>
        /// Test getting the books average read rate is equal to the expected member data.
        /// </summary>
        [Theory]
        [MemberData(nameof(BookBlTestMemberData.BookAverageReadRateData), MemberType = typeof(BookBlTestMemberData))]
        public async Task GetBookAverageReadRate(int bookId, BookHistory? bookHistory, int expectedAverageReadRate)
        {
            // Arrange
            _mockIBookDal.Setup(x => x.GetBookHistory(bookId)).ReturnsAsync(bookHistory);
            _bookBl = new BookBl(_mockIBookDal.Object);

            // Act
            var averageReadRate = await _bookBl.GetBookAverageReadRate(bookId);

            // Assert
            Assert.Equal(expectedAverageReadRate, averageReadRate);
        }
    }
}