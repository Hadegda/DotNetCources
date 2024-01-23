using System.Xml.Serialization;

namespace XamlSerialization
{
	internal static class SerializationHelper
	{
		public static void Serialize(string path, Department department)
		{
			XmlSerializer serializer = new(typeof(Department));

			using StreamWriter writer = new(path);

			serializer.Serialize(writer, department);

			writer.Dispose();
			writer.Close();
		}

		public static Department? Deserialize(string path)
		{
			XmlSerializer serializer = new(typeof(Department));

			using StreamReader reader = new(path);
			var department = (Department?)serializer.Deserialize(reader);
			reader.Dispose();
			reader.Close();

			return department;
		}
	}
}
