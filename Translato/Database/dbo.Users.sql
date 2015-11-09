﻿CREATE TABLE [dbo].[Users]
(
	[UserId] INT IDENTITY(1,1) NOT NULL,
    [UserName] NVARCHAR(15) NOT NULL,
    [HashedPassword] NVARCHAR(100) NOT NULL,
    [PasswordSalt] NVARCHAR(15) NOT NULL,
    [FirstName] NVARCHAR(20) NOT NULL,
    [LastName] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [NewsletterOptOut] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY ([UserId]),
	CONSTRAINT UNIQUE_USERNAME UNIQUE([UserName]),
	CONSTRAINT UNIQUE_EMAIL UNIQUE([Email])
)
