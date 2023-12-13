IF NOT EXISTS (SELECT * FROM dbo.Person WHERE Id = 1)
BEGIN
	INSERT INTO dbo.Person VALUES (1, 'Anna', 'South');
END
IF NOT EXISTS (SELECT * FROM dbo.Person WHERE Id = 2)
BEGIN
	INSERT INTO dbo.Person VALUES (2, 'Ivan', 'North');
END
IF NOT EXISTS (SELECT * FROM dbo.Person WHERE Id = 3)
BEGIN
	INSERT INTO dbo.Person VALUES (3, 'Vlad', 'West');
END
IF NOT EXISTS (SELECT * FROM dbo.Person WHERE Id = 4)
BEGIN
	INSERT INTO dbo.Person VALUES (4, 'Anna', 'East');
END

IF NOT EXISTS (SELECT * FROM dbo.Address WHERE Id = 1)
BEGIN
	INSERT INTO dbo.Address (Id, Street, City) VALUES (1, 'Baker', 'London');
END
IF NOT EXISTS (SELECT * FROM dbo.Address WHERE Id = 2)
BEGIN
	INSERT INTO dbo.Address (Id, Street, City) VALUES (2, 'Wide', 'London');
END
IF NOT EXISTS (SELECT * FROM dbo.Address WHERE Id = 3)
BEGIN
	INSERT INTO dbo.Address (Id, Street, City) VALUES (3, 'Pushkina', 'Batumi');
END
IF NOT EXISTS (SELECT * FROM dbo.Address WHERE Id = 4)
BEGIN
	INSERT INTO dbo.Address (Id, Street, City) VALUES (4, 'Baker', 'London');
END
IF NOT EXISTS (SELECT * FROM dbo.Address WHERE Id = 5)
BEGIN
	INSERT INTO dbo.Address (Id, Street, City, State, ZipCode) VALUES (5, 'Pushkina', 'Batumi', 'State', '6545');
END

IF NOT EXISTS (SELECT * FROM dbo.Employee WHERE Id = 1)
BEGIN
	INSERT INTO dbo.Employee VALUES (1, 1, 4, 'Epam', 'QA', 'SomeName');
END
IF NOT EXISTS (SELECT * FROM dbo.Employee WHERE Id = 2)
BEGIN
	INSERT INTO dbo.Employee (Id, AddressId, PersonId, CompanyName) VALUES (2, 3, 3, 'Epam');
END
IF NOT EXISTS (SELECT * FROM dbo.Employee WHERE Id = 3)
BEGIN
	INSERT INTO dbo.Employee VALUES (3, 4, 1, 'Epam', 'PM', 'SomeName');
END
IF NOT EXISTS (SELECT * FROM dbo.Employee WHERE Id = 4)
BEGIN
	INSERT INTO dbo.Employee (Id, AddressId, PersonId, CompanyName) VALUES (4, 5, 2, 'Epam');
END

IF NOT EXISTS (SELECT * FROM dbo.Company WHERE Id = 1)
BEGIN
	INSERT INTO dbo.Company VALUES (1, 'Epam', 2);
END