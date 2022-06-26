namespace StarterTreats.SimpleTasks.UnitTests
{
    public class SimpleTasksTestMemberData
    {
        public static IEnumerable<object[]> NumberIsPowerOfTwoData()
        {
            yield return new object[] { 0, false };
            yield return new object[] { 2, true };
            yield return new object[] { 8, true };
            yield return new object[] { 12, false };
            yield return new object[] { 31, false };
            yield return new object[] { 32, true };
            yield return new object[] { 64, true };
            yield return new object[] { 128, true };
            yield return new object[] { 250, false };
            yield return new object[] { 256, true };
        }
        public static IEnumerable<object[]> ReturnOddNumbersBetween1And100Data()
        {
            yield return new object[] { new List<int> { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59, 61, 63, 65, 67, 69, 71, 73, 75, 77, 79, 81, 83, 85, 87, 89, 91, 93, 95, 97, 99 } };
        }
    }
}
