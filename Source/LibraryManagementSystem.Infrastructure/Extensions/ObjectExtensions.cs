namespace LibraryManagementSystem.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert object to DBNull.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static object ToSqlNull(this object? input)
        {
            switch (input)
            {
                case null:
                case string value when string.IsNullOrWhiteSpace(value):
                    return DBNull.Value;
                case string:
                    return input;
                default:
                    return input;
            }
        }
    }
}