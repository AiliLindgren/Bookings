CREATE TABLE [dbo].[Reservation] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [NumberOfPeople] INT           NULL,
    [StartDateTime]      DATETIME2 (7) NULL,
    [EndDateTime]        DATETIME2 (7) NULL,
    [Contact]        NVARCHAR (64) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

