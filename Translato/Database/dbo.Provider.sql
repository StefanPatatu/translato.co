CREATE TABLE [dbo].[Provider]
(
	[ProviderId] INT IDENTITY(1,1) PRIMARY KEY, 
    [UserName] NVARCHAR(15) NOT NULL, 
    [HashedPassword] NVARCHAR(100) NOT NULL, 
    [PasswordSalt] NVARCHAR(15) NOT NULL
)
