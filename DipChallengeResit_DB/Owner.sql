CREATE TABLE [dbo].[Owner]
(
	[OwnerID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [GivenName] VARCHAR(50) NULL,
	[Surname] VARCHAR(50) NULL, 
    [phone] VARCHAR(50) NULL
)
