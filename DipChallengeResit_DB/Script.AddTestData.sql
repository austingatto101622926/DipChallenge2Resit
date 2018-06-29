/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF '$(AddSampleData)' = 'true'
BEGIN

DELETE [Treatment]
DELETE [Procedure]
DELETE [Pet]
DELETE [Owner];

SET IDENTITY_INSERT [Owner] ON;
INSERT INTO [Owner]([OwnerID],[GivenName],[Surname],[Phone]) VALUES
(1,'Sinatra','Frank',400111222),
(2,'Ellington','Duke',400222333),
(3,'Fitzgerald','Ella',400333444)
SET IDENTITY_INSERT [Owner] OFF;

SET IDENTITY_INSERT [Pet] ON;
INSERT INTO [Pet] ([petID],[Name],[Type],[OwnerID]) VALUES
(1,'Buster','Dog',1),
(2,'Fluffy','Cat',1),
(3,'Stew','Rabbit',2),
(4,'Buster','Dog',3),
(5,'Pooper','Dog',3)
SET IDENTITY_INSERT [Pet] OFF;

SET IDENTITY_INSERT [Procedure] ON;
INSERT INTO [Procedure] ([ProcedureID],[Description],[Price]) VALUES
(01,'Rabies Vaccination',24.00),
(10,'Examine and Treat Wound',30.00),
(05,'Heart Worm Test',25.00),
(08,'Tetnus Vaccination',17.00)
SET IDENTITY_INSERT [Procedure] OFF;

SET IDENTITY_INSERT [Treatment] ON;
INSERT INTO [Treatment]([TreatmentID],[ProcedureID],[PetID],[Date],[Notes],[price]) VALUES
(1,01,1,'2017-06-20','Routine Vaccination',22.00),
(2,01,1,'2018-05-15','Booster Shot',24.00),
(3,10,2,'2018-05-10','Wounds sustained in apparent cat fight.',30.00),
(4,10,3,'2018-05-10','Wounds sustained during attemot to cook the stew.',30.00),
(5,05,5,'2018-05-18','Routine Test',25.00)
SET IDENTITY_INSERT [Treatment] OFF;

END