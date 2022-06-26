using Xunit.Abstractions;

namespace StarterTreats.SimpleTasks.UnitTests
{
    public class SimpleTasksTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public SimpleTasksTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [MemberData(nameof(SimpleTasksTestMemberData.NumberIsPowerOfTwoData), MemberType = typeof(SimpleTasksTestMemberData))]
        public void NumberIsPowerOfTwo(int number, bool expected)
        {
            // Act
            var isPowerOfTwo = SimpleTasks.NumberIsPowerOfTwo(number);

            // Assert
            Assert.Equal(expected, isPowerOfTwo);
        }

        [Theory]
        [InlineData("Hello", "olleH")]
        [InlineData("ReverseString", "gnirtSesreveR")]
        [InlineData("DeVeLoPeR", "RePoLeVeD")]
        [InlineData("glue", "eulg")]
        [InlineData("Copy Me", "eM ypoC")]
        public void ReverseString(string stringValue, string expected)
        {
            // Act
            var result = SimpleTasks.ReverseString(stringValue);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", "The supplied value is null")]
        [InlineData(null, "The supplied value is null")]
        public void ReverseString_OnEmptyOrNull(string stringValue, string expected)
        {
            // Act
            var exception = Assert.Throws<Exception>(() => SimpleTasks.ReverseString(stringValue));

            // Assert
            Assert.Equal(expected, exception.Message);
        }

        [Theory]
        [InlineData("Hi", "HiHiHi", 3)]
        [InlineData("Hello", "HelloHelloHelloHelloHello", 5)]
        [InlineData("Bye", "ByeByeByeByeByeByeByeByeBye", 9)]
        public void RepeatString(string stringValue, string expected, int numberOfTimesToRepeat)
        {
            // Act
            var result = SimpleTasks.RepeatString(stringValue, numberOfTimesToRepeat);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", "The supplied value is null", 10)]
        [InlineData(null, "The supplied value is null", 11)]
        public void RepeatString_OnEmptyOrNull(string stringValue, string expected, int numberOfTimesToRepeat)
        {
            // Act
            var exception = Assert.Throws<Exception>(() => SimpleTasks.RepeatString(stringValue, numberOfTimesToRepeat));

            // Assert
            Assert.Equal(expected, exception.Message);
        }

        [Theory]
        [MemberData(nameof(SimpleTasksTestMemberData.ReturnOddNumbersBetween1And100Data), MemberType = typeof(SimpleTasksTestMemberData))]
        public void ReturnOddNumbersBetween1And100(List<int> expected)
        {
            // Act
            var result = SimpleTasks.ReturnOddNumbersBetween1And100();

            // Assert
            for (var i = 0; i < result.Count; i++)
            {
                Assert.Equal(expected[i], result[i]);
                _outputHelper.WriteLine($"One of the odd number are: {result[i]}.");
            }
        }
    }
}