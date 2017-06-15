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
	  --�ϴ��ļ���ԭʼ�ļ���
	filename nvarchar(255) not null,
	  --�ϴ��ļ��ڷ������б�����ļ�����
	filepath varchar(50) unique not null,
	  --�û�������ļ�������Ϣ
	description nvarchar(500) not null,
	  --�ϴ��ļ��Ĵ�С
	size int not null,
	  --�ϴ��ļ���mime����
	contentType nvarchar(100) not null,
	uploadDate datetime default getdate() not null
)
go

select * from TblFiles
go