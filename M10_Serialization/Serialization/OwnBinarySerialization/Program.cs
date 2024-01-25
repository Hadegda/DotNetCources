using System.Runtime.Serialization.Formatters.Binary;

namespace OwnBinarySerialization
{
	internal class Program
	{
		static void Main()
		{
			UserName user = new()
			{
				FullName = "Name Surname",
				ShortName = "Name"
			};

			string testPath = "D:\\DotNetCources\\M10_Serialization\\Serialization\\ownSerialization";

			SerializationHelper.Serialize(testPath, user);
			UserName res = SerializationHelper.Deserialize<UserName>(testPath);

			Console.WriteLine(res);
		}
	}
}