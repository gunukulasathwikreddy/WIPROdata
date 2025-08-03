use HospitalManagementSystem
Go

select * from DOCTOR_MASTER
go

select * from PATIENT_MASTER
go

select * from ROOM_MASTER
go

select * from ROOM_ALLOCATION
go

-- display patients who admitted in jan
select pid , admission_date from ROOM_ALLOCATION where datepart(mm,admission_date) = '01'
Go

-- display female patients who are not suffering from asthma
select * from PATIENT_MASTER where disease not in ('asthma') and Gender in ('F')
go

-- display count of male and female patients
select Gender, count(*) 'Patient Count' from PATIENT_MASTER group by(Gender)
Go

