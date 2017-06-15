use master
go
if(DB_ID('FileUpload') is not null)
   drop database FileUpload
go
create database FileUpload
go
use FileUpload

create table TblFiles
(
	fid int identity primary key not null,
	  --上传文件的原始文件名
	filename nvarchar(255) not null,
	  --上传文件在服务器中保存的文件名称
	filepath varchar(50) unique not null,
	  --用户输入的文件描述信息
	description nvarchar(500) not null,
	  --上传文件的大小
	size int not null,
	  --上传文件的mime类型
	contentType nvarchar(100) not null,
	uploadDate datetime default getdate() not null
)
go

select * from TblFiles
go