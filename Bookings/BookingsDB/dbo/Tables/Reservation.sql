CREATE TABLE [dbo].[Reservation] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [NumberOfPeople] INT           NULL,
    [StartTime]      DATETIME2 (7) NULL,
    [EndTime]        DATETIME2 (7) NULL,
    [Contact]        NVARCHAR (64) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

