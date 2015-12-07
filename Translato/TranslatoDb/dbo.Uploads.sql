CREATE TABLE [dbo].[Uploads]
(
	[UploadId] INT IDENTITY(1000000,1) NOT NULL,
	[TextId] INT NULL,
	[FileId] INT NULL,
	PRIMARY KEY ([UploadId]),
	FOREIGN KEY ([TextId]) REFERENCES [dbo].[Texts]([TextId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([FileId]) REFERENCES [dbo].[Files]([FileId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT CK_Uploads_Either_TextIdOrFileId CHECK (
		[Uploads].[TextId] IS NOT NULL AND [Uploads].[FileId] IS NULL
		OR
		[Uploads].[TextId] IS NULL AND [Uploads].[FileId] IS NOT NULL
	)
)
