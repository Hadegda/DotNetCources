/************************************************************************
* ## String Sum Kata
*
* Write a simple String Sum utility with a function <em>string Sum(string num1, string num2)</em>, which can accept only natural numbers and will return their sum. Replace entered number with <em>0 (zero)</em> if entered number is not a natural number.
* Stat with a simplest test case with an empty string
* Create a simple method <em>string Sum(string num1, string num2)</em>
* Write a test to pass small numbers and refactor, if test passed
* try to write more code and refactor
*
**************************************************************************/

using System;

namespace UnitTesting.StringSum
{
	public static class StringSum
	{
		private const double Tolerance = 1e-5;

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
			number >= 0 && Math.Abs(Math.Round(number) - number) < Tolerance;
	}
}
