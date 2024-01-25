using Newtonsoft.Json;

namespace JsonSerialization
{
	public class Employee
	{
		[JsonProperty(nameof(EmpoyeeName))]
		public string EmpoyeeName { get; set; } = string.Empty;
	}
}
