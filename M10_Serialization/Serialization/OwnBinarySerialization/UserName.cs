using System.Runtime.Serialization;

namespace OwnBinarySerialization
{
	[Serializable]
	internal class UserName : ISerializable
	{
		public string FullName { get; set; } = string.Empty;
		public string ShortName { get; set; } = string.Empty;

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(FullName), FullName);
			info.AddValue(nameof(ShortName), ShortName);
		}

		public UserName() { }

		public UserName(SerializationInfo info, StreamingContext ctxt)
		{
			FullName = (string?)info.GetValue(nameof(FullName), typeof(string)) ?? string.Empty;
			ShortName = (string?)info.GetValue(nameof(ShortName), typeof(string)) ?? string.Empty;
		}
	}
}
