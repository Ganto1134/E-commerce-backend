CREATE TABLE [dbo].[Prodotti] (
    [IDProdotto]          INT             IDENTITY (1, 1) NOT NULL,
    [Nome]                NVARCHAR (255)  NOT NULL,
    [Descrizione]         NVARCHAR (255)  NULL,
    [Prezzo]              DECIMAL (10, 2) NOT NULL,
    [Categoria]           NVARCHAR (100)  NULL,
    [DataInserimento]     DATETIME        DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([IDProdotto] ASC)
);

