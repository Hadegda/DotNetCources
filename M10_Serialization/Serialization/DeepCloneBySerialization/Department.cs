using Newtonsoft.Json;

namespace DeepCloneBySerialization
{
	public class Department
	{
		[JsonProperty(nameof(DepartmentName))]
		public string DepartmentName { get; set; } = string.Empty;

		[JsonProperty(nameof(Employees))]
		public List<Employee> Employees { get; set; } = new();

		public Department DeepClone()
		{
			string output = JsonConvert.SerializeObject(this);
			if (output == null)
			{
				throw new JsonSerializationException("Result of serialization is null");
			}

			return JsonConvert.DeserializeObject<Department>(output)!;
		}
	}
}
