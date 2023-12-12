CREATE VIEW [dbo].[EmployeeInfo]
	AS 
	SELECT [e].[Id], [p].[FirstName], [p].[LastName]
	FROM dbo.Employee e
	LEFT JOIN dbo.Person p ON e.PersonId = p.Id
