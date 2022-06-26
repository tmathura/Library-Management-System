namespace StarterTreats.SimpleTasks
{
    public static class SimpleTasks
    {
        public static bool NumberIsPowerOfTwo(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return (number & (number - 1)) == 0;
        }

        public static string ReverseString(string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                throw new Exception("The supplied value is null");
            }

            var charArray = stringValue.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string RepeatString(string stringValue, int numberOfTimesToRepeat)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                throw new Exception("The supplied value is null");
            }

            return string.Concat(Enumerable.Repeat(stringValue, numberOfTimesToRepeat));
        }

        public static List<int> ReturnOddNumbersBetween1And100()
        {
            var intList = new List<int>();
            for (var i = 1; i <= 100; i++)
            {
                if (i % 2 == 1)
                {
                    intList.Add(i);
                }
            }

            return intList;
        }

        public static void PrintOddNumbersBetween1And100()
        {
            var intList = ReturnOddNumbersBetween1And100();

            foreach (var i in intList)
            {
                Console.WriteLine(i);
            }
        }
    }
}