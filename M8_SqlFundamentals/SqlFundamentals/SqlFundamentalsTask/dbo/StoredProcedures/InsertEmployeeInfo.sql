CREATE PROCEDURE [dbo].[InsertEmployeeInfo]
	@EmployeeName nvarchar(100) = NULL,
	@FirstName nvarchar(50) = NULL, 
	@LastName nvarchar(50) = NULL, 
	@CompanyName nvarchar(20), 
	@Position nvarchar(30) = NULL, 
	@Street nvarchar(50), 
	@City nvarchar(20) = NULL, 
	@State nvarchar(50) = NULL, 
	@ZipCode nvarchar(50) = NULL
AS
BEGIN
	IF (@FirstName IS NULL OR TRIM(@FirstName) = '') AND
		(@LastName IS NULL OR TRIM(@LastName) = '') AND 
		(@EmployeeName IS NULL OR TRIM(@EmployeeName) = '')
	BEGIN
		RETURN -1;
	END

	DECLARE @AddressId INT;
	DECLARE @PersonId INT;

	INSERT INTO Address(Street, City, State, ZipCode) VALUES (@Street, @City, @State, @ZipCode)
	SET @AddressId = IDENT_CURRENT('Address');

	IF (@FirstName IS NULL OR TRIM(@FirstName) = '') OR
		(@LastName IS NULL OR TRIM(@LastName) = '')
	BEGIN
		INSERT INTO Person(FirstName, LastName) VALUES (@EmployeeName, @EmployeeName);
	END
	ELSE
	BEGIN
		INSERT INTO Person(FirstName, LastName) VALUES (@FirstName, @LastName);
	END
	SET @PersonId = IDENT_CURRENT('Person');

	INSERT INTO dbo.Employee VALUES (@AddressId, @PersonId, @CompanyName, @Position, @EmployeeName)
END