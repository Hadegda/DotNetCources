namespace BinarySerialization
{
	[Serializable]
	internal class Department
	{
		public string DepartmentName { get; set; } = string.Empty;
		public List<Employee> Employees { get; set; } = new();
	}
}
