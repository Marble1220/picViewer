-- =============================================
-- Create database on mulitple filegroups
-- =============================================
IF EXISTS (
  SELECT * 
    FROM sys.databases 
   WHERE name = N'gunterPicViewer'
)
  DROP DATABASE gunterPicViewer
GO

CREATE DATABASE gunterPicViewer
ON PRIMARY
	(NAME = 'gunterPicViewer_mainData',
	  FILENAME = N'D:\gunterPicViewer_mainData.mdf',
          SIZE = 10MB,
          MAXSIZE = 50MB,
          FILEGROWTH = 10%)

LOG ON
	( NAME = 'gunterPicViewer_log',
	  FILENAME = N'D:\gunterPicViewer_log.ldf',
          SIZE = 5MB,
          MAXSIZE = 25MB,
          FILEGROWTH = 5%)
GO

use gunterPicViewer
go
create table PicInfo
(
   ID int identity(1,1) primary key,
   picID ntext not null,
   uploadTime datetime,
   picComment ntext,
   picHight int default('300'),
   picWidth int default('600')

)
select * from PicInfo

create proc ViewPicInfo
as
(
    select * from PicInfo
    
)
create proc InsertPicInfo
(
  @picID ntext,
@picComment ntext,
@picHight int,
@picWidth int
)
as
begin
    insert into PicInfo(picID,picComment,picHight,picWidth) 
    values(@picID,@picComment,@picHight,@picWidth)
end
go

exec ViewPicInfo