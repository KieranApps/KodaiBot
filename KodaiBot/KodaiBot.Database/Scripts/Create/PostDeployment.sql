PRINT N'Inserting initial Database version...';
GO

INSERT INTO [KodaiBot].[DBVersion]
           ([ID]
           ,[MajorVersion]
		   ,[MinorVersion]
           ,[Remark]
		   ,[DateTimeStamp])

     VALUES
           (NEWID()
           ,'1'
		   ,'0'
           ,'Database created through create-script.'
		   ,GETDATE())

GO