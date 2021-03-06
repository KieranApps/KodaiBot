﻿CREATE TABLE [KodaiBot].[GuildAlias]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [GuildId] UNIQUEIDENTIFIER NOT NULL, 
    [AliasId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT [FK_GuildAlias_Guild] FOREIGN KEY ([GuildId]) REFERENCES [KodaiBot].[Guild]([Id]),
	CONSTRAINT [FK_GuildAlias_Alias] FOREIGN KEY ([AliasId]) REFERENCES [KodaiBot].[Alias]([Id])
)
