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
            yield return new object[] { 3, new List<string> { "Heather Solomon", "Hannes Bothma", "Thulani Booysen" } };
            yield return new object[] { 5, new List<string> { "Heather Solomon", "Hannes Bothma", "Thulani Booysen", "Clive Swanepoel", "Asanda Davies" } };
        }
    }
}
