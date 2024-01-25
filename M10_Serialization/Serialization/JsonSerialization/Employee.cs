using Newtonsoft.Json;

namespace JsonSerialization
{
	internal class Employee
	{
		[JsonProperty(nameof(EmpoyeeName))]
		public string EmpoyeeName { get; set; } = string.Empty;
	}
}
