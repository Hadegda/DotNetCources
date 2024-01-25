using Newtonsoft.Json;

namespace JsonSerialization
{
	internal class Department
	{
		[JsonProperty(nameof(DepartmentName))]
		public string DepartmentName { get; set; } = string.Empty;

		[JsonProperty(nameof(Employees))]
		public List<Employee> Employees { get; set; } = new();
	}
}
