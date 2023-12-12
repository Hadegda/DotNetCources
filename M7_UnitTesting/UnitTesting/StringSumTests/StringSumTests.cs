using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting.StringSum.Tests
{
	[TestClass()]
	public class StringSumTests
	{
		[TestMethod(), ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SumTest_EmptyStrings_ThrowsException()
		{
			StringSum.Sum("", "");
		}
	}
}