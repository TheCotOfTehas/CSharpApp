/*
Скрипт развертывания для C:\USERS\TSEBR\SOURCE\REPOS\CSHARPAPP\INFROSTRUCTURE\MEMORY\PERSONDB.MDF

Этот код был создан программным средством.
Изменения, внесенные в этот файл, могут привести к неверному выполнению кода и будут потеряны
в случае его повторного формирования.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "C:\USERS\TSEBR\SOURCE\REPOS\CSHARPAPP\INFROSTRUCTURE\MEMORY\PERSONDB.MDF"
:setvar DefaultFilePrefix "C_\USERS\TSEBR\SOURCE\REPOS\CSHARPAPP\INFROSTRUCTURE\MEMORY\PERSONDB.MDF_"
:setvar DefaultDataPath "C:\Users\tsebr\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\tsebr\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Проверьте режим SQLCMD и отключите выполнение скрипта, если режим SQLCMD не поддерживается.
Чтобы повторно включить скрипт после включения режима SQLCMD выполните следующую инструкцию:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Для успешного выполнения этого скрипта должен быть включен режим SQLCMD.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Идет создание Таблица [dbo].[Persons]…';


GO
CREATE TABLE [dbo].[Persons] (
    [Id]         INT        IDENTITY (1, 1) NOT NULL,
    [Name]       NCHAR (20) NULL,
    [Surname]    NCHAR (20) NULL,
    [Patronymic] NCHAR (20) NULL,
    [Gender]     NCHAR (20) NULL,
    [DateBirth]  DATE       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'Транзакции обновления базы данных успешно завершены.'
COMMIT TRANSACTION
END
ELSE PRINT N'Сбой транзакций обновления базы данных.'
GO
IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
GO
PRINT N'Обновление завершено.';


GO
