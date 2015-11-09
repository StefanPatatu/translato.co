CREATE TABLE [dbo].[Provider]
(
	[UserId] INT IDENTITY(1,1) PRIMARY KEY, 
    [UserName] NVARCHAR(15) NOT NULL, 
    [HashedPassword] NVARCHAR(100) NOT NULL, 
    [PasswordSalt] NVARCHAR(15) NOT NULL, 
    [FirstName] NVARCHAR(20) NOT NULL, 
    [LastName] NVARCHAR(20) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [EmailOptOut] BIT NOT NULL
)
