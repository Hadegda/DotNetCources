using Newtonsoft.Json;

namespace JsonSerialization
{
	internal static class SerializationHelper
	{
		public static void Serialize(string path, Department department)
		{
			JsonSerializer serializer = new();

			using StreamWriter sw = new(path);
			using JsonWriter writer = new JsonTextWriter(sw);

			serializer.Serialize(writer, department);

			sw.Close();
		}

		public static Department? Deserialize(string path)
		{
			JsonSerializer serializer = new();

			using StreamReader sr = new(path);
			using JsonReader reader = new JsonTextReader(sr);

			var department = serializer.Deserialize<Department>(reader);

			sr.Close();

			return department;
		}
	}
}
