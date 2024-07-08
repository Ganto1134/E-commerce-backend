CREATE TABLE [dbo].[Unione] (
    [IDUnione] INT             IDENTITY (1, 1) NOT NULL,
    [CarrelloID]         INT             NOT NULL,
    [ProdottoID]         INT             NOT NULL,
    [Quantita]           INT             NOT NULL,
    [PrezzoUnitario]     DECIMAL (10, 2) NOT NULL,
    [DataAggiunta]       DATETIME        DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([IDUnione] ASC),
    FOREIGN KEY ([CarrelloID]) REFERENCES [dbo].[Carrelli] ([IDCarrello]),
    FOREIGN KEY ([ProdottoID]) REFERENCES [dbo].[Prodotti] ([IDProdotto])
);

