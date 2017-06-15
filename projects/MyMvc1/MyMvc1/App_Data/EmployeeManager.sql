use master
go
if(DB_ID('EmployeeManager') is not null)
     drop database EmployeeManager
go
create database EmployeeManager
go
use EmployeeManager
go

create table TblDept
(
   deptId int identity(1000,1) primary key,
   deptName nvarchar(20) unique not null,
   deptInfo nvarchar(100) not null,
)
go

create table TblEmployee
(
   eid int identity(100000,1) primary key,
   deptId int foreign key references TblDept(deptId) not null,
   ename nvarchar(20) not null,
   sex char(1) check(sex in ('m','f')) not null,
   salary decimal(10,2) check(salary>0) not null,
   indate datetime default getdate() not null
)
go

insert into TblDept(deptName,deptInfo) values('人事部','管理人员的部门')
insert into TblDept(deptName,deptInfo) values('开发部','程序猿的部门')
insert into TblDept(deptName,deptInfo) values('生活部','管理生活')
go

select * from TblDept
go

select * from TblEmployee
go