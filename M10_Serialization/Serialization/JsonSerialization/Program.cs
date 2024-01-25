using Newtonsoft.Json;

namespace JsonSerialization
{
	internal class Program
	{
		static void Main()
		{
			Department department = new() { DepartmentName = "TestDepartmentJson" };

			department.Employees.Add(new Employee() { EmpoyeeName = "emp0" });
			department.Employees.Add(new Employee() { EmpoyeeName = "emp1" });
			department.Employees.Add(new Employee() { EmpoyeeName = "emp2" });

			string testPath = "D:\\DotNetCources\\M10_Serialization\\Serialization\\test.json";

			SerializationHelper.Serialize(testPath, department);
			var res = SerializationHelper.Deserialize(testPath);

			Console.WriteLine(res);
		}
	}
}