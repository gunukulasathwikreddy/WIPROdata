select len('misissipi') - len(replace('misissipi','i','')) 'count'
Go

select len('keerthi') - charindex('e',reverse('keerthi'))+1 'last occurence'
Go

select SUBSTRING('Venkata Narayana',1,charindex(' ','Venkata Narayana')-1) 'first name',
       SUBSTRING('Venkata Narayana',charindex(' ','Venkata Narayana')+1,len('Venkata Narayana')) 'last name'
Go

SELECT EOMONTH(GETDATE(), 1) AS LastDayOfNextMonth
Go

select dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	'First Friday',
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))))
	'Second Friday',
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))))
	'Third Friday',
	DATEADD(dd,7,
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))))) 
	'Fourth Friday', 
	case when Month(
		DateAdd(dd,7, 
	DATEADD(dd,7,
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))))))) 

	) = MONTH(GetDate()) THEN 
	DateAdd(dd,7, 
	DATEADD(dd,7,
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))))))) 
	ELSE 'No Fifth Friday IN this Month' END 
	'Fifth Friday'