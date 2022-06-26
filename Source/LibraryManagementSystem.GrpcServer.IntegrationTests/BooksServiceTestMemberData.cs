namespace LibraryManagementSystem.GrpcServer.IntegrationTests
{
    public class BooksServiceTestMemberData
    {
        public static IEnumerable<object[]> TopBorrowedBooksData()
        {
            yield return new object[] { 3, new List<int> { 13, 3, 1 } };
            yield return new object[] { 5, new List<int> { 13, 3, 1, 2, 4 } };
        }

        public static IEnumerable<object[]> TopBorrowersData()
        {
            yield return new object[] { 3, 2, new List<int> { 2, 1 }, new DateTime(2022, 04, 01), new DateTime(2022, 04, 24) };
            yield return new object[] { 3, 3, new List<int> { 2, 3, 1 }, new DateTime(2022, 04, 15), new DateTime(2022, 05, 28) };
            yield return new object[] { 3, 3, new List<int> { 2, 1, 3 }, new DateTime(2022, 04, 01), new DateTime(2022, 06, 28) };
            yield return new object[] { 5, 5, new List<int> { 2, 1, 3, 4, 5 }, new DateTime(2022, 04, 01), new DateTime(2022, 06, 28) };
        }

        public static IEnumerable<object[]> BorrowerBorrowedTimeFrameCountData()
        {
            yield return new object[] { 1, new List<DateTime> { new(2022, 04, 01), new(2022, 05, 01) }, new List<DateTime> { new(2022, 04, 14), new(2022, 05, 14) }, new List<int> { 2, 1 } };
            yield return new object[] { 2, new List<DateTime> { new(2022, 04, 01), new(2022, 04, 15), new(2022, 05, 15) }, new List<DateTime> { new(2022, 04, 14), new(2022, 04, 28), new(2022, 05, 28) }, new List<int> { 1, 3, 1 } };
        }

        public static IEnumerable<object[]> OtherBorrowedBooksData()
        {
            yield return new object[] { 13, 5, new List<int> { 1, 2, 3, 4, 13 } };
        }

        public static IEnumerable<object?[]> GetAllBooksData()
        {
            yield return new object?[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 } };
        }

        public static IEnumerable<object?[]> GetBookHistoryDetailData()
        {
            yield return new object?[]
            {
                999,
                new List<DateTime>(),
                new List<DateTime>(),
                new List<DateTime>(),
                new List<int>()
            };
            yield return new object?[]
            {
                5,
                new List<DateTime>(),
                new List<DateTime>(),
                new List<DateTime>(),
                new List<int>()
            };
            yield return new object?[]
            {
                13,
                new List<DateTime> { new(2022, 04, 01), new(2022, 05, 15), new(2022, 05, 15), new(2022, 06, 15) },
                new List<DateTime> { new(2022, 04, 14), new(2022, 05, 28), new(2022, 05, 28), new(2022, 06, 28) },
                new List<DateTime> { new(2022, 04, 14), new(2022, 05, 22), new(2022, 05, 28), new(2022, 06, 25) },
                new List<int> { 13, 7, 13, 10 }
            };
        }
    }
}
