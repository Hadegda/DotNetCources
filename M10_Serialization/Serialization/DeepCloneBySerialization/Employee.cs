using Newtonsoft.Json;

namespace DeepCloneBySerialization
{
	public class Employee
	{
		[JsonProperty(nameof(EmpoyeeName))]
		public string EmpoyeeName { get; set; } = string.Empty;
	}
}
