create database HospitalManagementSystem
Go

use HospitalManagementSystem
Go

Create Table DOCTOR_MASTER 
(
	doctor_id varchar(15) constraint pk_doctor_master_doctor_id primary key,
	doctor_name varchar(15) NOT NULL,
	Dept varchar(15) NOT NULL
)
GO

Insert into DOCTOR_MASTER(doctor_id,doctor_name,Dept) 
values('D0001','Ram','ENT'),
('D0002','Rajan','ENT'),
('D0003','Smitha','Eye'),
('D0004','Bhavan','Surgery'),
('D0005','Sheela','Surgery'),
('D0006','Nethra','Surgery')
GO

select * from DOCTOR_MASTER
Go

Create Table ROOM_MASTER
(
	room_no varchar(15) constraint pk_room_master_room_no primary key,
	room_type varchar(15) NOT NULL,
	status varchar(15) NOT NULL
)
GO

Insert into ROOM_MASTER(room_no,room_type,status) 
values('R0001','AC','occupied'),
('R0002','Suite','vacant'),
('R0003','NonAC','vacant'),
('R0004','NonAC','occupied'),
('R0005','AC','vacant'),
('R0006','AC','occupied')
GO

select * from ROOM_MASTER
Go

Create Table PATIENT_MASTER
(
	pid varchar(15) constraint pk_patient_master_pid primary key,
	name varchar(15) NOT NULL,
	age INT NOT NULL,
	Weight INT NOT NULL,
	Gender varchar(15) NOT NULL, 
	Address varchar(50) NOT NULL,
	phoneno varchar(10) NOT NULL,
	Disease varchar(50) NOT NULL,
	Doctor_id varchar(15) Constraint FK_DOCTOR_MASTER_doctor_id FOREIGN KEY(doctor_id) REFERENCES DOCTOR_MASTER(doctor_id)
)
GO

Insert into PATIENT_MASTER(pid,name,age,Weight,Gender,Address,phoneno,Disease,Doctor_id)
values ('P0001','Gita',35,65,'F','Chennai',9867145678,'Eye Infection','D0003'),
('P0002','Ashish',40,70,'M','Delhi',9845675678,'Asthma','D0003'),
('P0003','Radha',25,60,'F','Chennai',9867166678,'Pain in Heart','D0005'),
('P0004','Chandra',28,55,'F','Bangalore',9978675567,'Asthma','D0001'),
('P0005','Goyal',42,65,'M','Delhi',8967533223,'Pain in Stomach','D0004')
Go

select * from PATIENT_MASTER
Go

Create Table ROOM_ALLOCATION
(
	room_no varchar(15) Constraint FK_ROOM_ALLOCATION_room_no FOREIGN KEY(room_no) REFERENCES ROOM_MASTER(room_no),
	pid varchar(15) Constraint FK_ROOM_ALLOCATION_pid FOREIGN KEY(pid) REFERENCES PATIENT_MASTER(pid),
	admission_date date NOT NULL,
	Release_date date
)
Go

Insert into ROOM_ALLOCATION(room_no,pid,admission_date,Release_date)
values
('R0001','P0001','2016-10-15','2016-10-26'),
('R0002','P0002','2016-11-15','2016-11-26'),
('R0002','P0003','2016-12-01','2016-12-30'),
('R0004','P0001','2017-01-01','2017-01-30')
Go

select * from ROOM_ALLOCATION
Go