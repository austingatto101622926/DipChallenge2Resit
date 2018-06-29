CREATE TABLE [dbo].[Treatment]
(
	[TreatmentID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Date] DATE NULL, 
    [Notes] VARCHAR(300) NULL, 
    [Price] MONEY NULL,

	[ProcedureID] INT NOT NULL,
	[PetID] INT NOT NULL,

	FOREIGN KEY ([ProcedureID]) REFERENCES [Procedure]([ProcedureID]) ,
	FOREIGN KEY ([PetID]) REFERENCES [Pet]([PetID]) 
)
