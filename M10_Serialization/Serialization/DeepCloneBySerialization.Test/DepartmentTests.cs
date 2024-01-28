namespace DeepCloneBySerialization.Test
{
	[TestClass]
	public class DepartmentTests
	{
		[TestMethod]
		public void TestDeepClone_NoEmployees_ClonedSuccessfully()
		{
			Department department = new() { DepartmentName = "TestDepartment" };

			var actual = department.DeepClone();

			Assert.IsNotNull(actual);
			AssertAreDeepClones(expected: department, actual);
		}

		[TestMethod]
		public void TestDeepClone_WithEmployees_ClonedSuccessfully()
		{
			Department department = new() { DepartmentName = "TestDepartment" };

			department.Employees.Add(new Employee() { EmpoyeeName = "emp0" });
			department.Employees.Add(new Employee() { EmpoyeeName = "emp1" });
			department.Employees.Add(new Employee() { EmpoyeeName = "emp2" });

			var actual = department.DeepClone();

			Assert.IsNotNull(actual);
			AssertAreDeepClones(expected: department, actual);
		}

		private static void AssertAreDeepClones(Department expected, Department actual)
		{
			Assert.AreEqual(expected.DepartmentName, actual.DepartmentName);
			Assert.AreNotEqual(expected.Employees, actual.Employees);
			Assert.AreEqual(expected.Employees.Count, actual.Employees.Count);

			for (int i = 0; i < expected.Employees.Count; i++)
			{
				Assert.AreNotEqual(expected.Employees[i], actual.Employees[i]);
				Assert.AreEqual(expected.Employees[i].EmpoyeeName, actual.Employees[i].EmpoyeeName);
			}
		}
	}
}