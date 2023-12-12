CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(20) NOT NULL, 
    [AddressId] INT NOT NULL, 
    CONSTRAINT [CompanyAddress.Id] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
