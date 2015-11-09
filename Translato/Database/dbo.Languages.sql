CREATE TABLE [dbo].[Languages]
(
	[LanguageId] INT IDENTITY(1,1) NOT NULL,
    [LanguageName] NVARCHAR(15) NOT NULL,
	PRIMARY KEY ([LanguageId]),
	CONSTRAINT UNIQUE_LANGUAGE UNIQUE([LanguageName])
)
