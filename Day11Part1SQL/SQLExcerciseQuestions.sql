select len('misissipi') - len(replace('misissipi','i','')) 'count'
Go

select len('keerthi') - charindex('e',reverse('keerthi'))+1 'last occurence'
Go

select SUBSTRING('Venkata Narayana',1,charindex(' ','Venkata Narayana')-1) 'first name',
       SUBSTRING('Venkata Narayana',charindex(' ','Venkata Narayana')+1,len('Venkata Narayana')) 'last name'
Go

SELECT EOMONTH(GETDATE(), 1) AS LastDayOfNextMonth
Go