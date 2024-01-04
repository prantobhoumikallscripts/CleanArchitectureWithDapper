CREATE TABLE [dbo].[Accounts] (
    [CustomerId] INT           NOT NULL,
    [AccountNo]  INT           IDENTITY (1, 1) NOT NULL,
    [BranchName] NVARCHAR (50) NOT NULL,
    [BankName]   NVARCHAR (50) NOT NULL,
    [Balance]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
);


