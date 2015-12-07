CREATE TABLE [dbo].[Languages]
(
	[LanguageId] INT IDENTITY(1000000,1) NOT NULL,
    [LanguageName] NVARCHAR(15) NOT NULL,
	PRIMARY KEY ([LanguageId]),
	CONSTRAINT CK_Languages_Unique_LanguageName UNIQUE([LanguageName])
)
