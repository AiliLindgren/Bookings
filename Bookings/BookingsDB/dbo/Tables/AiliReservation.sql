CREATE TABLE [dbo].[AiliReservation] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [NumberOfPeople] INT           NOT NULL,
    [Date]           DATE          NOT NULL,
    [StartTime]      TIME (7)      NOT NULL,
    [EndTime]        TIME (7)      NOT NULL,
    [created_at]     DATETIME2 (7) NOT NULL,
    [Contact]        NVARCHAR (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
