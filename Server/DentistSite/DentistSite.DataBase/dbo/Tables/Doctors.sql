CREATE TABLE [dbo].[Doctors] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [Age]       INT            NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Image] IMAGE NULL, 
    CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

