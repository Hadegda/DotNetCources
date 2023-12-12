using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.CalcStats.Tests
{
	[TestClass]
	public class CalcStatsTests
	{
		[TestMethod]
		public void CalculateStatsTest_EmptyArray_StatsAreDefault()
		{
			var expected = new Stats();

			var actual = CalcStats.CalculateStats(1);

			Assert.AreEqual(expected, actual);
		}
	}
}