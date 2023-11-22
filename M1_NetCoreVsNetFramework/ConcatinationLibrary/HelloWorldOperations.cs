namespace ConcatenationLibrary
{
	public static class HelloWorldOperations
	{
		public static string CreateHelloUserRecord(string userName)
			=> RecordsHelper.ToRecord(CreateHelloUserString(userName));

		public static string CreateHelloUserString(string userName)
			=> $"Hello, {userName}!";
	}
}

