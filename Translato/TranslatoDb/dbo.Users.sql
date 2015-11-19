CREATE TABLE [dbo].[Users]
(
	[UserId] INT IDENTITY(1,1) NOT NULL,
    [UserName] VARCHAR(15) NOT NULL,
    [HashedPassword] CHAR(1024) NOT NULL,
    [FirstName] NVARCHAR(20) NOT NULL,
    [LastName] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [NewsletterOptOut] BIT NOT NULL DEFAULT 0,
	[CreatedOn] DATETIMEOFFSET(0) DEFAULT SYSDATETIMEOFFSET() NOT NULL, 
    PRIMARY KEY ([UserId]),
	CONSTRAINT CK_Users_Unique_UserName UNIQUE([UserName]),
	CONSTRAINT CK_Users_Unique_Email UNIQUE([Email])
)
