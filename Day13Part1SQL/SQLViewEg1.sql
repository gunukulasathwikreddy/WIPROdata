create view vwEmploy
AS
	select * from Employ 
GO

select * from vwEmploy 
GO

create view vwEmployReport
AS
	select Empno, Name, Gender, Dept, Basic, dbo.Fncommission(Basic) 'Commission',
			Basic - dbo.Fncommission(Basic) 'Take Home' from Employ
GO

select * from vwEmployReport 
GO