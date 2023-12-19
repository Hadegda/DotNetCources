namespace UnitTesting.CalcStats
{
	public readonly struct Stats
	{
		public int MinValue { get; }
		public int MaxValue { get; }
		public int Size { get; }
		public double Average { get; }

		public Stats(int minValue, int maxValue, int size, double average)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			Size = size;
			Average = average;
		}
	}
}
