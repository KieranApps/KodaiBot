CREATE TABLE [KodaiBot].[GuildUserSnapshot]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [GuildUserId] UNIQUEIDENTIFIER NOT NULL, 
    [SnapshotId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT [FK_GuildUserSnapshot_GuildUser] FOREIGN KEY ([GuildUserId]) REFERENCES [KodaiBot].[GuildUser]([Id]),
	CONSTRAINT [FK_GuildUserSnapshot_Snapshot] FOREIGN KEY ([SnapshotId]) REFERENCES [KodaiBot].[Snapshot]([Id])
)
