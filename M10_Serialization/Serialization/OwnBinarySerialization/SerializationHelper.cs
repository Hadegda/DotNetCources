using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OwnBinarySerialization
{
	internal static class SerializationHelper
	{
		public static void Serialize<T>(string path, T data)
		{
			Stream stream = File.Open(path, FileMode.OpenOrCreate);

			BinaryFormatter formatter = new();

			formatter.Serialize(stream, data);

			stream.Close();
		}

		public static T Deserialize<T>(string path)
		{
			Stream stream = File.Open(path, FileMode.Open);

			BinaryFormatter formatter = new();

			var data = (T)formatter.Deserialize(stream);

			stream.Close();

			return data;
		}
	}
}
