CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NCHAR(20) NULL, 
    [Surname] NCHAR(20) NULL, 
    [Patronymic] NCHAR(20) NULL, 
    [Gender] NCHAR(20) NULL, 
    [DateBirth] DATE NULL
)
