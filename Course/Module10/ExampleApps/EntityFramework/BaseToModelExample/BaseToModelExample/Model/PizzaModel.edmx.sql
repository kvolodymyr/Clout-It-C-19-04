
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/25/2019 16:53:01
-- Generated from EDMX file: E:\Cloud-It\_Examples\EntityFramework\BaseToModelExample\BaseToModelExample\Model\PizzaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PizzaShop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Pizza_Recipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pizza] DROP CONSTRAINT [FK_Pizza_Recipe];
GO
IF OBJECT_ID(N'[dbo].[FK_RecipeItems_Ingredient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipeItems] DROP CONSTRAINT [FK_RecipeItems_Ingredient];
GO
IF OBJECT_ID(N'[dbo].[FK_RecipeItems_Recipe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipeItems] DROP CONSTRAINT [FK_RecipeItems_Recipe];
GO
IF OBJECT_ID(N'[dbo].[FK_Table_Pizza]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Table] DROP CONSTRAINT [FK_Table_Pizza];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Ingredient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingredient];
GO
IF OBJECT_ID(N'[dbo].[Pizza]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pizza];
GO
IF OBJECT_ID(N'[dbo].[Recipe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recipe];
GO
IF OBJECT_ID(N'[dbo].[RecipeItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecipeItems];
GO
IF OBJECT_ID(N'[dbo].[Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Ingredient'
CREATE TABLE [dbo].[Ingredient] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Measure] int  NOT NULL,
    [Amount] int  NOT NULL
);
GO

-- Creating table 'Pizza'
CREATE TABLE [dbo].[Pizza] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Recipe'
CREATE TABLE [dbo].[Recipe] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Time] datetime  NOT NULL,
    [Persons] int  NOT NULL
);
GO

-- Creating table 'RecipeItems'
CREATE TABLE [dbo].[RecipeItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IngredientId] int  NOT NULL,
    [Amount] int  NOT NULL,
    [Measure] int  NOT NULL,
    [RecipeId] int  NOT NULL
);
GO

-- Creating table 'Table'
CREATE TABLE [dbo].[Table] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PizzaId] int  NOT NULL,
    [OrderedAt] datetime  NOT NULL
);
GO

-- Creating table 'MarketSet'
CREATE TABLE [dbo].[MarketSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Ingredient'
ALTER TABLE [dbo].[Ingredient]
ADD CONSTRAINT [PK_Ingredient]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pizza'
ALTER TABLE [dbo].[Pizza]
ADD CONSTRAINT [PK_Pizza]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Recipe'
ALTER TABLE [dbo].[Recipe]
ADD CONSTRAINT [PK_Recipe]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecipeItems'
ALTER TABLE [dbo].[RecipeItems]
ADD CONSTRAINT [PK_RecipeItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Table'
ALTER TABLE [dbo].[Table]
ADD CONSTRAINT [PK_Table]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarketSet'
ALTER TABLE [dbo].[MarketSet]
ADD CONSTRAINT [PK_MarketSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IngredientId] in table 'RecipeItems'
ALTER TABLE [dbo].[RecipeItems]
ADD CONSTRAINT [FK_RecipeItems_Ingredient]
    FOREIGN KEY ([IngredientId])
    REFERENCES [dbo].[Ingredient]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecipeItems_Ingredient'
CREATE INDEX [IX_FK_RecipeItems_Ingredient]
ON [dbo].[RecipeItems]
    ([IngredientId]);
GO

-- Creating foreign key on [Id] in table 'Pizza'
ALTER TABLE [dbo].[Pizza]
ADD CONSTRAINT [FK_Pizza_Recipe]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Recipe]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PizzaId] in table 'Table'
ALTER TABLE [dbo].[Table]
ADD CONSTRAINT [FK_Table_Pizza]
    FOREIGN KEY ([PizzaId])
    REFERENCES [dbo].[Pizza]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Table_Pizza'
CREATE INDEX [IX_FK_Table_Pizza]
ON [dbo].[Table]
    ([PizzaId]);
GO

-- Creating foreign key on [RecipeId] in table 'RecipeItems'
ALTER TABLE [dbo].[RecipeItems]
ADD CONSTRAINT [FK_RecipeItems_Recipe]
    FOREIGN KEY ([RecipeId])
    REFERENCES [dbo].[Recipe]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecipeItems_Recipe'
CREATE INDEX [IX_FK_RecipeItems_Recipe]
ON [dbo].[RecipeItems]
    ([RecipeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------