namespace StarterTreats.SimpleTasks.UnitTests
{
    public class SimpleTasksTests
    {
        [Theory]
        [MemberData(nameof(SimpleTasksTestMemberData.NumberIsPowerOfTwoData), MemberType = typeof(SimpleTasksTestMemberData))]
        public void NumberIsPowerOfTwo(int number, bool expected)
        {
            // Act
            var isPowerOfTwo = SimpleTasks.NumberIsPowerOfTwo(number);

            // Assert
            Assert.Equal(expected, isPowerOfTwo);
        }
    }
}