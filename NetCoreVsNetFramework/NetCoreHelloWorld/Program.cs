namespace NetCoreHelloWorld
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var username = args.Length > 0 ? args[0] : "NoName";
			Console.WriteLine($"Hello, {username}");
		}
	}
}