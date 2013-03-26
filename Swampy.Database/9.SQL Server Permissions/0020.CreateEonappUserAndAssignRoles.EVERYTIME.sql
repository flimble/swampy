If not Exists (SELECT * FROM sys.database_principals WHERE name = N'eonapp')
Begin
CREATE USER [eonapp] FOR LOGIN [eonapp]
END
EXEC sp_addrolemember N'db_datareader', N'eonapp'
EXEC sp_addrolemember N'db_datawriter', N'eonapp'
grant execute to eonapp
