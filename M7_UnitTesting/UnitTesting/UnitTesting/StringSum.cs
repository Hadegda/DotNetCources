using System;

namespace UnitTesting.StringSum
{
	public static class StringSum
	{
		public static string Sum(string num1, string num2)
		{
			if (!double.TryParse(num1, out double number1) || !double.TryParse(num2, out double number2))
			{
				throw new ArgumentOutOfRangeException();
			}

			number1 = IsNatural(number1) ? number1 : 0;
			number2 = IsNatural(number2) ? number2 : 0;

			return (number1 + number2).ToString();
		}

		private static bool IsNatural(double number) => 
			number >= 0 && number == Math.Round(number);
	}
}
