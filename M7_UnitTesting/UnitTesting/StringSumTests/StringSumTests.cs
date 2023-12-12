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
		[DataRow("0", "1", "1")]
		[DataRow("1", "0", "1")]
		public void SumTest_ValidArguments_CountCorrectly(string num1, string num2, string expectedValue)
		{
			var actualValue = StringSum.Sum(num1, num2);

			Assert.AreEqual(expectedValue, actualValue);
		}
	}
}