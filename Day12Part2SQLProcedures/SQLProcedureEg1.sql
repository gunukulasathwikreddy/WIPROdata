if exists(select * from sysobjects where name = 'ProcSayHello')
Drop Proc ProcSayHello
GO

create proc ProcSayHello
AS
BEGIN
		Print 'Hello Welocome to T-SQL'
END
Go

Exec ProcSayHello
Go
