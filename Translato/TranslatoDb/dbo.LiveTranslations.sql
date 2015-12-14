CREATE TABLE [dbo].[LiveTranslations]
(
	[LiveTranslationId] INT IDENTITY(1000000,1) NOT NULL,
	[DateCreated] DATETIMEOFFSET(0) DEFAULT SYSDATETIMEOFFSET() NOT NULL,
	[ProviderId] INT NOT NULL,
	[PricePerHour] DECIMAL(13,2) DEFAULT 0 NOT NULL,
	[Language1Id] INT NOT NULL,
	[Language2Id] INT NOT NULL,
	[Language3Id] INT DEFAULT NULL NULL,
	[Language4Id] INT DEFAULT NULL NULL,
	[Language5Id] INT DEFAULT NULL NULL,
	[DateStarted] DATETIMEOFFSET(0) DEFAULT NULL NULL,
	[RequesterId] INT DEFAULT NULL NULL,
	[DateEnded] DATETIMEOFFSET(0) DEFAULT NULL NULL,
	PRIMARY KEY ([LiveTranslationId]),
	FOREIGN KEY ([ProviderId]) REFERENCES dbo.[Users]([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language1Id]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language2Id]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language3Id]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language4Id]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language5Id]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY (RequesterId) REFERENCES dbo.[Users]([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT CK_LiveTranslations_Meaningful_Dates CHECK (
		(
			[DateCreated] <= [DateStarted]
			OR
			[DateStarted] IS NULL
		)
		AND
		(
			[DateStarted] < [DateEnded]
			OR
			(
				[DateStarted] IS NULL
				AND
				[DateEnded] IS NULL
			)
			OR
			(
				[DateStarted] IS NOT NULL
				AND
				[DateEnded] IS NULL
			)
		)	
	),
	CONSTRAINT CK_LiveTranslations_Different_LanguagesIds CHECK (
		[Language1Id]	!= [Language2Id]
		AND
		(
			( 
			[Language2Id] != [Language3Id]
			) 
			OR
			( 
				[Language3Id] IS NULL
			) 
		)
		AND
		(
			(
			[Language3Id] != [Language4Id]
			)
			OR
			(
				[Language3Id] IS NOT NULL AND [Language4Id] IS NULL
			)
			OR
			(
				[Language3Id] IS NULL AND [Language4Id] IS NULL
			) 
		) 
		AND
		(
			(
			[Language4Id] != [Language5Id]
			)
			OR
			(
				[Language4Id] IS NOT NULL AND [Language5Id] IS NULL
			)
			OR
			(
				[Language4Id] IS NULL AND [Language5Id] IS NULL
			) 
		)
	)
)
