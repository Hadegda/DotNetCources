using static System.Net.Mime.MediaTypeNames;
using System;

namespace UnitTesting.StringSum
{
	public static class StringSum
	{
		public static string Sum(string num1, string num2)
		{
			if (int.TryParse(num1, out int number1) || int.TryParse(num2, out int number2))
			{
				throw new ArgumentOutOfRangeException();
			}

			return "";
		}
	}
}
