--CREATE DATABASE [Authentication];

--USE [Authentication];

--IF NOT EXISTS (
--    SELECT * 
--    FROM sys.sql_logins 
--    WHERE name = 'SA'
--)
--BEGIN
--    CREATE LOGIN [SA] WITH PASSWORD = '!1PasswordAuthentication.';
--END

--IF NOT EXISTS (
--    SELECT * 
--    FROM sys.database_principals 
--    WHERE name = 'SA'
--)
--BEGIN
--    CREATE USER [SA] FOR LOGIN [SA];
--END

--ALTER ROLE [db_owner] ADD MEMBER [SA];
