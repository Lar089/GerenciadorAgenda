CREATE TABLE [dbo].[TBContatos] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [nome]     VARCHAR (200) NULL,
    [email]    VARCHAR (200) NULL,
    [telefone] VARCHAR (200) NULL,
    [empresa]  VARCHAR (200) NULL,
    [cargo]    VARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

