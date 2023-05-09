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

﻿CREATE TABLE [foreign_names] 
( 
	[id] [int] NOT NULL, 
	[name] [varchar](25) NOT NULL, 
	[meaning] [varchar](1000) NOT NULL, 
	[gender] [varchar](6) NOT NULL, 
	[origin] [varchar](24) NOT NULL, 
	[PeoplesCount] [int] NULL, 
	[WhenPeoplesCount] [datetime] NULL, 
	[Source] [nvarchar](10) NOT NULL 
); 

CREATE TABLE [russian_names] 
( 
	[ID] [int] NOT NULL, 
	[Name] [nvarchar](100) NOT NULL, 
	[Sex] [nvarchar](1) NULL, 
	[PeoplesCount] [int] NULL, 
	[WhenPeoplesCount] [datetime] NULL, 
	[Source] [varchar](10) NULL 
); 

CREATE TABLE [russian_surnames] 
( 
	[ID] [int] NOT NULL, 
	[Surname] [nvarchar](100) NOT NULL, 
	[Sex] [nvarchar](1) NULL, 
	[PeoplesCount] [int] NULL, 
	[WhenPeoplesCount] [datetime] NULL, 
	[Source] [varchar](50) NULL 
); 