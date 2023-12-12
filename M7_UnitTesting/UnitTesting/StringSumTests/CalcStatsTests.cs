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

		[TestMethod]
		public void CalculateStatsTest_SingleElementArray_CorrectStatsReturned()
		{
			var expected = new Stats
			{
				minValue = 1,
				maxValue = 1,
				size = 1,
				average = 1
			};

			var actual = CalcStats.CalculateStats(1);

			Assert.AreEqual(expected, actual);
		}
	}
}