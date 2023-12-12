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
		[DataRow("5", null)]
		[DataRow(null, "5")]
		public void SumTest_InvalidArguments_ThrowsException(string num1, string num2)
		{
			StringSum.Sum(num1, num2);
		}
	}
}