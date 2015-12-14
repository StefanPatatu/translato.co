CREATE TABLE [dbo].[LiveTranslations]
(
	[LiveTranslationId] INT IDENTITY(1000000,1) NOT NULL,
	[DateCreated] DATETIMEOFFSET(0) DEFAULT SYSDATETIMEOFFSET() NOT NULL,
	[ProviderId] INT NOT NULL,
	[PricePerHour] DECIMAL(13,2) DEFAULT 0 NOT NULL,
	[Language1] INT NOT NULL,
	[Language2] INT NOT NULL,
	[Language3] INT DEFAULT NULL NULL,
	[Language4] INT DEFAULT NULL NULL,
	[Language5] INT DEFAULT NULL NULL,
	[DateStarted] DATETIMEOFFSET(0) DEFAULT NULL NULL,
	[RequesterId] INT DEFAULT NULL NULL,
	[DateEnded] DATETIMEOFFSET(0) DEFAULT NULL NULL,
	PRIMARY KEY ([LiveTranslationId]),
	FOREIGN KEY ([ProviderId]) REFERENCES dbo.[Users]([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language1]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language2]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language3]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language4]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([Language5]) REFERENCES dbo.[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
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
		[Language1]	!= [Language2]
		AND
		(
			( 
			[Language2] != [Language3]
			) 
			OR
			( 
				[Language3] IS NULL
			) 
		)
		AND
		(
			(
			[Language3] != [Language4]
			)
			OR
			(
				[Language3] IS NOT NULL AND [Language4] IS NULL
			)
			OR
			(
				[Language3] IS NULL AND [Language4] IS NULL
			) 
		) 
		AND
		(
			(
			[Language4] != [Language5]
			)
			OR
			(
				[Language4] IS NOT NULL AND [Language5] IS NULL
			)
			OR
			(
				[Language4] IS NULL AND [Language5] IS NULL
			) 
		)
	)
)
