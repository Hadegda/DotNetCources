using System.Xml.Serialization;

namespace XamlSerialization
{
	public class Department
	{
		[XmlElementAttribute("DepartmentName")]
		public string DepartmentName { get; set; } = string.Empty;

		[XmlElementAttribute("Employees")]
		public List<Employee> Employees { get; set; } = new();
	}
}
