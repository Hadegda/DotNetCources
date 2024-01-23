using System.Xml.Serialization;

namespace XamlSerialization
{
	public class Employee
	{
		[XmlElementAttribute("EmpoyeeName")]
		public string EmpoyeeName { get; set; } = string.Empty;
	}
}
