CREATE TABLE [KodaiBot].[DbVersion]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [MajorVersion] INT NOT NULL, 
    [MinorVersion] INT NOT NULL, 
    [Remark] NVARCHAR(256) NULL, 
    [DateTimeStamp] SMALLDATETIME NOT NULL
)
