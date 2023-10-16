using System;

namespace ConcatenationLibrary
{
	public static class RecordsHelper
	{
		public static string ToRecord(string str)
			=> $"{DateTime.Now.ToShortTimeString()} {str}";
	}
}
