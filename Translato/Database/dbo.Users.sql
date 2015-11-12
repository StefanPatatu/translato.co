CREATE TABLE [dbo].[Users]
(
	[UserId] INT IDENTITY(1,1) NOT NULL,
    [UserName] NVARCHAR(15) NOT NULL,
    [HashedPassword] CHAR(1024) NOT NULL,
    [PasswordSalt] CHAR(512) NOT NULL,
    [FirstName] NVARCHAR(20) NOT NULL,
    [LastName] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [NewsletterOptOut] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY ([UserId]),
	CONSTRAINT CK_Users_Unique_UserName UNIQUE([UserName]),
	CONSTRAINT CK_Users_Unique_Email UNIQUE([Email])
)
