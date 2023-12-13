CREATE VIEW [dbo].[EmployeeInfo]
	AS 
	SELECT 
		[e].[Id] AS EmployeeId, 
		COALESCE(TRIM([e].[EmployeeName]), [p].[FirstName] + ' ' + [p].[LastName]) AS EmployeeFullName, 
		TRIM(COALESCE([a].[ZipCode], 'NoZipCode')) + '_' + TRIM(COALESCE([a].[State], 'NoState')) + ', ' + 
			TRIM(COALESCE([a].[City], 'NoCity')) + '-' + TRIM([a].[Street]) AS EmployeeFullAddress, 
		CONCAT(TRIM([e].[CompanyName]), '(', TRIM(COALESCE([e].[Position], 'NotSpecified')), ')') AS EmployeeCompanyInfo
	FROM dbo.Employee e
	LEFT JOIN dbo.Person p ON e.PersonId = p.Id
	LEFT JOIN dbo.Address a ON e.AddressId = a.Id
