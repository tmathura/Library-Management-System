namespace LibraryManagementSystem.Infrastructure.IntegrationTests
{
    public class BookDalTestMemberData
    {
        public static IEnumerable<object[]> TopBorrowedBooksData()
        {
            yield return new object[] { 3, new List<string> { "Dante's Equation", "Silverthorn", "Magician: Apprentice" } };
            yield return new object[] { 5, new List<string> { "Dante's Equation", "Silverthorn", "Magician: Apprentice", "Magician: Master", "A Darkness At Sethanon" } };
        }

        public static IEnumerable<object[]> TopBorrowersData()
        {
            yield return new object[] { 3, 2, new List<string> { "Heather Solomon", "Hannes Bothma" }, new DateTime(2022, 04, 01), new DateTime(2022, 04, 24) };
            yield return new object[] { 3, 3, new List<string> { "Heather Solomon", "Thulani Booysen", "Hannes Bothma" }, new DateTime(2022, 04, 15), new DateTime(2022, 05, 28) };
            yield return new object[] { 3, 3, new List<string> { "Heather Solomon", "Hannes Bothma", "Thulani Booysen" }, new DateTime(2022, 04, 01), new DateTime(2022, 06, 28) };
            yield return new object[] { 5, 5, new List<string> { "Heather Solomon", "Hannes Bothma", "Thulani Booysen", "Clive Swanepoel", "Asanda Davies" }, new DateTime(2022, 04, 01), new DateTime(2022, 06, 28) };
        }
        public static IEnumerable<object[]> BorrowerBorrowedTimeFrameCountData()
        {
            yield return new object[] { 1, new List<DateTime> { new(2022, 04, 01), new(2022, 05, 01) }, new List<DateTime> { new(2022, 04, 14), new(2022, 05, 14) }, new List<int> { 2, 1 } };
            yield return new object[] { 2, new List<DateTime> { new(2022, 04, 01), new(2022, 04, 15), new(2022, 05, 15) }, new List<DateTime> { new(2022, 04, 14), new(2022, 04, 28), new(2022, 05, 28) }, new List<int> { 1, 3, 1 } };
        }
    }
}
