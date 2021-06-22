CREATE TABLE [dbo].[TBTarefa] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [titulo]              VARCHAR (200) NULL,
    [dataCriacao]         DATETIME      NULL,
    [dataConclusao]       DATETIME      NOT NULL,
    [percentualConcluido] INT           NULL,
    [prioridade]          INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

