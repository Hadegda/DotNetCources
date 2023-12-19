DELETE FROM dbo.Employee;
DELETE FROM dbo.Company;
DELETE FROM dbo.Person;
DELETE FROM dbo.Address;

INSERT INTO dbo.Person VALUES ('Anna', 'South');
INSERT INTO dbo.Person VALUES ('Ivan', 'North');
INSERT INTO dbo.Person VALUES ('Vlad', 'West');
INSERT INTO dbo.Person VALUES ('Anna', 'East');

INSERT INTO dbo.Address (Street, City) VALUES ('Baker', 'London');
INSERT INTO dbo.Address (Street, City) VALUES ('Wide', 'London');
INSERT INTO dbo.Address (Street, City) VALUES ('Pushkina', 'Batumi');
INSERT INTO dbo.Address (Street, City) VALUES ('Baker', 'Rome');
INSERT INTO dbo.Address (Street, City, State, ZipCode) VALUES ('Pushkina', 'Rome', 'State', '6545');


INSERT INTO dbo.Employee (AddressId, PersonId, CompanyName, Position, EmployeeName)
	SELECT a.Id, p.Id, 'Epam', 'Dev', 'Anna South-West'
	FROM dbo.Address a
	INNER JOIN dbo.Person p ON p.FirstName = 'Anna' AND p.LastName = 'South' AND a.Street = 'Pushkina' AND a.City = 'Batumi'

	
INSERT INTO dbo.Employee (AddressId, PersonId, CompanyName)
	SELECT a.Id, p.Id, 'Epam'
	FROM dbo.Address a
	INNER JOIN dbo.Person p ON p.FirstName = 'Vlad' AND p.LastName = 'West' AND a.Street = 'Pushkina' AND a.City = 'Rome'

	
INSERT INTO dbo.Company (Name, AddressId)
	SELECT 'Epam', a.Id
	FROM dbo.Address a Where a.Street = 'Pushkina' AND a.City = 'Rome'