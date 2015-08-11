
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/26/2015 09:28:12
-- Generated from EDMX file: c:\users\shibu\documents\visual studio 2015\Projects\learning\EF\Employee\Employee\EmmployeeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFDB01];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [EmploymentType] int  NOT NULL
);
GO

-- Creating table 'Technologies'
CREATE TABLE [dbo].[Technologies] (
    [TechnologyId] int IDENTITY(1,1) NOT NULL,
    [SkillsetName] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [YearsOfExperience] nvarchar(max)  NOT NULL,
    [EmployeeEmployeeID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [TechnologyId] in table 'Technologies'
ALTER TABLE [dbo].[Technologies]
ADD CONSTRAINT [PK_Technologies]
    PRIMARY KEY CLUSTERED ([TechnologyId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeEmployeeID] in table 'Technologies'
ALTER TABLE [dbo].[Technologies]
ADD CONSTRAINT [FK_EmployeeTechnology]
    FOREIGN KEY ([EmployeeEmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTechnology'
CREATE INDEX [IX_FK_EmployeeTechnology]
ON [dbo].[Technologies]
    ([EmployeeEmployeeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------