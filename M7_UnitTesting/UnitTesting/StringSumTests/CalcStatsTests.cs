using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting.CalcStats.Tests
{
	[TestClass]
	public class CalcStatsTests
	{
		[TestMethod]
		public void CalculateStatsTest_EmptyArray_StatsAreDefault()
		{
			var expected = new Stats();

			var actual = CalcStats.CalculateStats();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CalculateStatsTest_NullArgument_ExceptionThrown()
		{
			CalcStats.CalculateStats(null);
		}
	}
}