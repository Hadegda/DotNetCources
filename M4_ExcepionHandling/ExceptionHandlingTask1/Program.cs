using System;

namespace ExceptionHandlingTask1
{
    internal class Program
    {
		private delegate void LineOperaion(string line);

        private static void Main()
        {
			LoopThroughInput('0', PrintFirstCharacter);
		}

		private static void LoopThroughInput(char stopSymbol, LineOperaion lineOperation)
		{
			do
			{
				var line = Console.ReadLine();

				if (line == null || (line.Length == 1 && line[0] == stopSymbol))
				{
					break;
				}

				lineOperation(line);
			}
			while (true);
		}

		private static void PrintFirstCharacter(string line)
		{
			try
			{
				Console.WriteLine(line[0]);
			}
			catch
			{
				Console.WriteLine("Error: empty string");
			}
		}
	}
}