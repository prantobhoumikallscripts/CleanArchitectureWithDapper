CREATE TABLE [dbo].[Customers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [FullName]    NVARCHAR (50) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    [PhoneNumber] NVARCHAR (10) NULL,
    [RegionId]    INT           NOT NULL,
    [Address]     NVARCHAR (50) NULL,
    [DOB]         DATETIME      NOT NULL,
    [Gender]      NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);




