
CREATE TABLE [dbo].[Addresses] (
    [Id]         INT           NOT NULL,
    [CityId]     INT           NULL,
    [Street]     VARCHAR (150) NULL,
    [Cep]        NCHAR (8)     NULL,
    [Number]     INT           NULL,
    [Complement] VARCHAR (255)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
