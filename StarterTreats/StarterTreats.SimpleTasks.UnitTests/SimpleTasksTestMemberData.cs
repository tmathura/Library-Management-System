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
    }
}
