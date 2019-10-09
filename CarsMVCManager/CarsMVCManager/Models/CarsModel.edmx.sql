
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/25/2019 16:58:44
-- Generated from EDMX file: C:\Users\userI13\Desktop\houssem_tp4\CarsMVCManager\CarsMVCManager\Models\CarsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarsDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProprietaireVoiture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VoitureSet] DROP CONSTRAINT [FK_ProprietaireVoiture];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProprietaireSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProprietaireSet];
GO
IF OBJECT_ID(N'[dbo].[VoitureSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VoitureSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProprietaireSet'
CREATE TABLE [dbo].[ProprietaireSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Numpermis] nvarchar(max)  NOT NULL,
    [Contact_Email] nvarchar(max)  NOT NULL,
    [Contact_Tel] nvarchar(max)  NOT NULL,
    [Contact_Adresse] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VoitureSet'
CREATE TABLE [dbo].[VoitureSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [PFiscale] int  NOT NULL,
    [Marque] int  NOT NULL,
    [Modele] int  NOT NULL,
    [Carburant] int  NOT NULL,
    [Matricule] nvarchar(max)  NOT NULL,
    [Couleur] nvarchar(max)  NOT NULL,
    [ProprietaireId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProprietaireSet'
ALTER TABLE [dbo].[ProprietaireSet]
ADD CONSTRAINT [PK_ProprietaireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VoitureSet'
ALTER TABLE [dbo].[VoitureSet]
ADD CONSTRAINT [PK_VoitureSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProprietaireId] in table 'VoitureSet'
ALTER TABLE [dbo].[VoitureSet]
ADD CONSTRAINT [FK_ProprietaireVoiture]
    FOREIGN KEY ([ProprietaireId])
    REFERENCES [dbo].[ProprietaireSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProprietaireVoiture'
CREATE INDEX [IX_FK_ProprietaireVoiture]
ON [dbo].[VoitureSet]
    ([ProprietaireId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------