using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting.StringSum.Tests
{
	[TestClass]
	public class StringSumTests
	{
		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		[DataRow("", "")]
		[DataRow("5", "")]
		[DataRow("", "5")]
		[DataRow("5", "4gf")]
		[DataRow("4fg", "5")]
		[DataRow("5", "-4gf")]
		[DataRow("+4fg", "5")]
		public void SumTest_InvalidArguments_ThrowsException(string num1, string num2)
		{
			StringSum.Sum(num1, num2);
		}

		[TestMethod]
		[DataRow("3", "8", "11")]
		[DataRow("0", "+1", "1")]
		[DataRow("1", "+0", "1")]
		public void SumTest_ValidArguments_CountCorrectly(string num1, string num2, string expectedValue)
		{
			var actualValue = StringSum.Sum(num1, num2);

			Assert.AreEqual(expectedValue, actualValue);
		}

		[TestMethod]
		public void SumTest_SumValuesWithIntOverflow_CountCorrectly()
		{
			var expectedValue = ((long)int.MaxValue + int.MaxValue).ToString();

			var actualValue = StringSum.Sum(int.MaxValue.ToString(), int.MaxValue.ToString());

			Assert.AreEqual(expectedValue, actualValue);
		}

		[TestMethod]
		[DataRow("3", "-8", "3")]
		[DataRow("-8", "3", "3")]
		[DataRow("3", "2.5", "3")]
		[DataRow("2.5", "3", "3")]
		[DataRow("-2.5", "-2.5", "0")]
		public void SumTest_SumWithNotNaturalValue_CountCorrectly(string num1, string num2, string expectedValue)
		{
			var actualValue = StringSum.Sum(num1, num2);

			Assert.AreEqual(expectedValue, actualValue);
		}
	}
}