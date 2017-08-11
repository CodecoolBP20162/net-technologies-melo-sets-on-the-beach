
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2017 11:23:57
-- Generated from EDMX file: E:\codecool\advanced-MeLo\net-technologies-melo-sets-on-the-beach\MeLo\MeLo\Models\MeLoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MeLoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TypeExtension]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExtensionSet] DROP CONSTRAINT [FK_TypeExtension];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet] DROP CONSTRAINT [FK_MediaType];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaPlaylist_MediaSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaPlaylist] DROP CONSTRAINT [FK_MediaPlaylist_MediaSet];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaPlaylist_PlaylistSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaPlaylist] DROP CONSTRAINT [FK_MediaPlaylist_PlaylistSet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ExtensionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExtensionSet];
GO
IF OBJECT_ID(N'[dbo].[MediaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet];
GO
IF OBJECT_ID(N'[dbo].[PlaylistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaylistSet];
GO
IF OBJECT_ID(N'[dbo].[TypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeSet];
GO
IF OBJECT_ID(N'[dbo].[MediaPlaylist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaPlaylist];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ExtensionSet'
CREATE TABLE [dbo].[ExtensionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [TypeId] int  NOT NULL
);
GO

-- Creating table 'MediaSet'
CREATE TABLE [dbo].[MediaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [TypeId] int  NOT NULL
);
GO

-- Creating table 'PlaylistSet'
CREATE TABLE [dbo].[PlaylistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TypeSet'
CREATE TABLE [dbo].[TypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MediaPlaylist'
CREATE TABLE [dbo].[MediaPlaylist] (
    [MediaSet_Id] int  NOT NULL,
    [PlaylistSet_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ExtensionSet'
ALTER TABLE [dbo].[ExtensionSet]
ADD CONSTRAINT [PK_ExtensionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaSet'
ALTER TABLE [dbo].[MediaSet]
ADD CONSTRAINT [PK_MediaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlaylistSet'
ALTER TABLE [dbo].[PlaylistSet]
ADD CONSTRAINT [PK_PlaylistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeSet'
ALTER TABLE [dbo].[TypeSet]
ADD CONSTRAINT [PK_TypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MediaSet_Id], [PlaylistSet_Id] in table 'MediaPlaylist'
ALTER TABLE [dbo].[MediaPlaylist]
ADD CONSTRAINT [PK_MediaPlaylist]
    PRIMARY KEY CLUSTERED ([MediaSet_Id], [PlaylistSet_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TypeId] in table 'ExtensionSet'
ALTER TABLE [dbo].[ExtensionSet]
ADD CONSTRAINT [FK_TypeExtension]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[TypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeExtension'
CREATE INDEX [IX_FK_TypeExtension]
ON [dbo].[ExtensionSet]
    ([TypeId]);
GO

-- Creating foreign key on [TypeId] in table 'MediaSet'
ALTER TABLE [dbo].[MediaSet]
ADD CONSTRAINT [FK_MediaType]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[TypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaType'
CREATE INDEX [IX_FK_MediaType]
ON [dbo].[MediaSet]
    ([TypeId]);
GO

-- Creating foreign key on [MediaSet_Id] in table 'MediaPlaylist'
ALTER TABLE [dbo].[MediaPlaylist]
ADD CONSTRAINT [FK_MediaPlaylist_MediaSet]
    FOREIGN KEY ([MediaSet_Id])
    REFERENCES [dbo].[MediaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PlaylistSet_Id] in table 'MediaPlaylist'
ALTER TABLE [dbo].[MediaPlaylist]
ADD CONSTRAINT [FK_MediaPlaylist_PlaylistSet]
    FOREIGN KEY ([PlaylistSet_Id])
    REFERENCES [dbo].[PlaylistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaPlaylist_PlaylistSet'
CREATE INDEX [IX_FK_MediaPlaylist_PlaylistSet]
ON [dbo].[MediaPlaylist]
    ([PlaylistSet_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------