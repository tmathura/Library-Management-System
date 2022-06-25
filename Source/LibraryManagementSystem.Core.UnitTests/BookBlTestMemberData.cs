using LibraryManagementSystem.Domain.Models;
using Moq;

namespace LibraryManagementSystem.Core.UnitTests
{
    public class BookBlTestMemberData
    {
        public static IEnumerable<object?[]> BookAverageReadRateData()
        {
            yield return new object?[] { It.IsAny<int>(),
                null,
                0 };
            yield return new object?[] { It.IsAny<int>(),
                new BookHistory
                {
                    TotalPages = 496,
                    BookHistoryDetails = new List<BookHistoryDetail>
                    {
                        new()
                        {
                            DaysLoaned = 13
                        },
                        new()
                        {
                            DaysLoaned = 7
                        },
                        new()
                        {
                            DaysLoaned = 13
                        },
                        new()
                        {
                            DaysLoaned = 10
                        }
                    }
                },
                49 };
            yield return new object?[] { It.IsAny<int>(),
                new BookHistory
                {
                    TotalPages = 500,
                    BookHistoryDetails = new List<BookHistoryDetail>
                    {
                        new()
                        {
                            DaysLoaned = 10
                        },
                        new()
                        {
                            DaysLoaned = 10
                        },
                        new()
                        {
                            DaysLoaned = 10
                        },
                        new()
                        {
                            DaysLoaned = 10
                        },
                        new()
                        {
                            DaysLoaned = 10
                        }
                    }
                },
                50 };
            yield return new object?[] { It.IsAny<int>(),
                new BookHistory
                {
                    TotalPages = 369,
                    BookHistoryDetails = new List<BookHistoryDetail>
                    {
                        new()
                        {
                            DaysLoaned = 5
                        },
                        new()
                        {
                            DaysLoaned = 7
                        },
                        new()
                        {
                            DaysLoaned = 9
                        },
                        new()
                        {
                            DaysLoaned = 3
                        },
                        new()
                        {
                            DaysLoaned = 14
                        },
                        new()
                        {
                            DaysLoaned = 11
                        }
                    }
                },
                59 };
        }
    }
}
