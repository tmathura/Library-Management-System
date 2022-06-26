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
    }
}