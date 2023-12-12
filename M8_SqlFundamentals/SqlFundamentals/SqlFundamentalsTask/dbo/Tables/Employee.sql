CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[AddressId] INT NOT NULL, 
    [PersonId] INT NOT NULL, 
    [CompanyName] NCHAR(20) NOT NULL, 
    [Position] NCHAR(30) NULL, 
    [EmployeeName] NCHAR(100) NULL, 
    CONSTRAINT [EmployeeAddress.Id] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]),
    CONSTRAINT [Person.Id] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]),
)
