BEGIN TRANSACTION
GO
-- CHANGES TO DATABASE HERE


-- VERSION UPDATE VERIFICATION
IF EXISTS (SELECT [MajorVersion] FROM [KodaiBot].[DbVersion] WHERE [MajorVersion] = 0 AND [MinorVersion] = 0)

	BEGIN
		UPDATE	[KodaiBot].[DbVersion] 
		SET		[MajorVersion] = 1
					, [MinorVersion] = 0
					, [Remark] = 'Initial database script'
					, [DateTimeStamp] = GETDATE()
		WHERE	[MajorVersion] = 0 AND [MinorVersion] = 0

		COMMIT TRANSACTION 

		PRINT 'Update Complete - Version updated to 1.0'
	END

ELSE

	BEGIN
		PRINT 'Invalid version was detected. Version 0.0 expected. Rolling back transaction...'
		ROLLBACK TRANSACTION
	END

GO