using System;

namespace ConcatinationLibrary
{
	public static class ConcatinationOps
	{
		public static string CreateHelloWorldString (string username)
		{
			return $"{DateTime.Now.ToShortTimeString()} Hello, {username}!";
		}
	}
}

