CREATE TABLE [dbo].[Regions]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [RegionName] NCHAR(20) NULL, 
    [RegionCode] NCHAR(10) NULL, 
    [Continants] NCHAR(20) NULL
)
