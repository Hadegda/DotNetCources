/************************************************************************
## Calc Stats Kata

Your task is to process a sequence of integer numbers
to determine the following statistics:

* minimum value
* maximum value
* number of elements in the sequence
* average value

For example: [6, 9, 15, -2, 92, 11]

* minimum value = -2
* maximum value = 92
* number of elements in the sequence = 6
* average value = 18.166666
*
**************************************************************************/

using System;
using System.Linq;

namespace UnitTesting.CalcStats
{
	public static class CalcStats
	{
		public static Stats CalculateStats(params int[] sequence)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException();
			}

			if (sequence.Length == 0)
			{
				return new Stats();
			}

			var stats = new Stats
			{
				minValue = sequence.Min(),
				maxValue = sequence.Max(),
				size = sequence.Length,
				average = sequence.Average()
			};

			return stats;
		}
	}
}
