using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
	internal static class SerializationHelper
	{
		public static void Serialize(string path, Department department)
		{
			Stream stream = File.Open(path, FileMode.OpenOrCreate);

			BinaryFormatter formatter = new();

			formatter.Serialize(stream, department);

			stream.Close();
		}

		public static Department Deserialize(string path)
		{
			Stream stream = File.Open(path, FileMode.Open);

			BinaryFormatter formatter = new();

			var department = (Department)formatter.Deserialize(stream);

			stream.Close();

			return department;
		}
	}
}
