CREATE TABLE [dbo].[foreign_names2]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[name] NCHAR(20),
	[meaning] NCHAR(20),
	[gender] NCHAR(20),
	[origin] NCHAR(20),
	[PeoplesCount]  INT,
	[WhenPeoplesCount]  DATETIME,
	[Source]  NCHAR(20)
)
