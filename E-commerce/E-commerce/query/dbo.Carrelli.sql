CREATE TABLE [dbo].[Carrelli] (
    [IDCarrello]    INT           IDENTITY (1, 1) NOT NULL,
    [IDUtente]      INT           NOT NULL,
    [DataCreazione] DATETIME      DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([IDCarrello] ASC)
);

