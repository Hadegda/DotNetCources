using ConcatinationLibrary;

namespace NetCoreHelloWorld
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var username = GetUsername(args);
			Console.WriteLine(ConcatinationOps.CreateHelloWorldString(username));
		}

		static bool AreArgsValid(string[] args) 
			=> args.Length > 0;

		static string GetUsername(string[] args)
			=> AreArgsValid(args) ? args[0] : "NoName";
	}
}