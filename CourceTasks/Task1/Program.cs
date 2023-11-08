using System;
#nullable enable

namespace ExceptionHandlingTask1
{
    internal class Program
    {
        private static void Main()
        {
			while (PrintFirstCharacter(Console.ReadLine())) { };
		}

		private static bool PrintFirstCharacter(string? line)
		{
			if (line == null)
			{
				return false;
			}

			try
			{
				Console.WriteLine(line[0]);
			}
			catch
			{
				Console.WriteLine("Error: empty string");
			}
			return true;
		}
	}
}