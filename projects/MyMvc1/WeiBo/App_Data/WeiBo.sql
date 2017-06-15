use master
go

if(DB_ID('WeiBo') is not null)
    drop database WeiBo
go

create database WeiBo
go

use Weibo
go

create table TblUser
(
	uid int identity primary key not null,
	username nvarchar(20) unique not null,
	password nvarchar(20) not null,
	nickname nvarchar(50) not null,
	regDate datetime default getdate() not null
)
go

insert into TblUser(username,password,nickname) values('admin','123456','���ù���Ա')
go

select * from TblUser
go

--΢����Ϣ��
create table TblMessage
(
	mid int identity primary key not null,
	uid int foreign key references TblUser(uid) not null,
	title nvarchar(50) not null,
	content nvarchar(2000) not null,
	created datetime default getdate() not null,
	deleted char(1) default'n' not null
)
go

select * from TblMessage
go

--�ظ�
create table TblReturn
(
	rid int identity primary key not null,
	mid int foreign key references TblMessage(mid) not null,
	uid int foreign key references TblUser(uid) not null,
	content nvarchar(500) not null,
	created datetime default getdate() not null
)
go

select * from TblReturn
go