using System;

namespace ExceptionHandlingTask2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
				throw new ArgumentNullException();
			}

			stringValue = stringValue.Trim();
			if (stringValue.Length == 0)
			{
				throw new FormatException();
			}
			
			return ConvertLongToInt(ConvertStringToLong(stringValue));
		}

		private static long ConvertStringToLong(string stringValue)
		{
			char? sign = GetSign(stringValue);
			int i = sign != null ? 1 : 0;

			long res = ConvertCharToInt(stringValue[i]);

			for (i++; i < stringValue.Length; i++)
			{
				res = res * 10 + ConvertCharToInt(stringValue[i]);
			}

			return sign == '-' ? -res : res;
		}

		private static char? GetSign(string stringValue)
		{
			if (stringValue[0] == '+' || stringValue[0] == '-')
			{
				return stringValue[0];
			}
			return null;
		}

		private static int ConvertCharToInt(char c)
		{
			if (c < '0' || c > '9')
			{
				throw new FormatException();
			}
			return c - '0';
		}

		private static int ConvertLongToInt(long number)
		{
			if (number < int.MinValue || number > int.MaxValue)
			{
				throw new OverflowException();
			}
			return (int)number;
		}
	}
}