CREATE TABLE [dbo].[Production] (
    [ProductionId]       INT          NOT NULL,
    [Title]              VARCHAR (50) NOT NULL,
    [Description]        VARCHAR (50) NOT NULL,
    [PlayWright]         VARCHAR (50) NOT NULL,
    [Runtime]            INT          NOT NULL,
    [OpeningDay]         DATETIME     NOT NULL,
    [ClosingDay]         DATETIME     NOT NULL,
    [ShowTimeEve]        DATETIME     NULL,
    [Season]             INT          NOT NULL,
    [IsWorldPremiere]    BIT          NOT NULL,
    [TicketLink]         VARCHAR (50) NOT NULL,
    [IsCurrentlyShowing] BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductionId] ASC)
);

