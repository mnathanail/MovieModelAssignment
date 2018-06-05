namespace MovieModelAssignment
{
    public static class ValidationUtils
    {
        public static long IsLong(string input)
        {
            bool result = long.TryParse(input, out long longNumber);
            return (result == true ? longNumber : 0);
        }

        public static decimal IsDecimal(string input)
        {
            bool result = decimal.TryParse(input, out decimal decimalNumber);
            return (result == true ? decimalNumber : 0);
        }
    }
}
