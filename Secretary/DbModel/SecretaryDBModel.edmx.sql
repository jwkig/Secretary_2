
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server Compact Edition
-- --------------------------------------------------
-- Date Created: 02/02/2018 13:48:44
-- Generated from EDMX file: C:\Proj\Secretary\Secretary_2\Secretary\DbModel\SecretaryDBModel.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    ALTER TABLE [PublisherReports] DROP CONSTRAINT [FK_PublisherPublisherReport];
GO
    ALTER TABLE [PublisherReports] DROP CONSTRAINT [FK_PublisherReportCongregationReport];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- NOTE: if the table does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    DROP TABLE [CongregationReports];
GO
    DROP TABLE [PublisherReports];
GO
    DROP TABLE [Publishers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CongregationReports'
CREATE TABLE [CongregationReports] (
    [Id] uniqueidentifier  NOT NULL,
    [Month] smallint  NULL,
    [Year] smallint  NULL,
    [SendDate] datetime  NULL,
    [Publishers_NumberOfPublishers] smallint  NULL,
    [Publishers_Hours] smallint  NULL,
    [Publishers_Returns] smallint  NOT NULL,
    [Publishers_Studies] smallint  NULL,
    [AuxPioneers_NumberOfPublishers] smallint  NULL,
    [AuxPioneers_Hours] smallint  NULL,
    [AuxPioneers_Returns] smallint  NOT NULL,
    [AuxPioneers_Studies] smallint  NULL,
    [Pioneers_NumberOfPublishers] smallint  NULL,
    [Pioneers_Hours] smallint  NULL,
    [Pioneers_Returns] smallint  NOT NULL,
    [Pioneers_Studies] smallint  NULL,
    [ActivePublishers] smallint  NULL
);
GO

-- Creating table 'PublisherReports'
CREATE TABLE [PublisherReports] (
    [Id] uniqueidentifier  NOT NULL,
    [Month] tinyint  NULL,
    [Year] smallint  NULL,
    [Publications] smallint  NULL,
    [VideoPresentations] smallint  NULL,
    [Hours] smallint  NOT NULL,
    [Returns] smallint  NULL,
    [Studies] smallint  NULL,
    [Notes] nvarchar(255)  NULL,
    [PublisherId] uniqueidentifier  NOT NULL,
    [CongrReportId] uniqueidentifier  NULL
);
GO

-- Creating table 'Publishers'
CREATE TABLE [Publishers] (
    [Id] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [SecondName] nvarchar(50)  NULL,
    [PatronymicName] nvarchar(100)  NULL,
    [BirhtDade] datetime  NULL,
    [BaptizeDate] datetime  NULL,
    [Hope] int  NOT NULL,
    [Address] nvarchar(255)  NULL,
    [FixedPhone] nvarchar(50)  NULL,
    [MobilePhone] nvarchar(50)  NULL,
    [IsElder] bit  NULL,
    [IsServant] bit  NULL,
    [IsPioneer] bit  NULL,
    [IsActive] bit  NULL,
    [IsRegular] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CongregationReports'
ALTER TABLE [CongregationReports]
ADD CONSTRAINT [PK_CongregationReports]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'PublisherReports'
ALTER TABLE [PublisherReports]
ADD CONSTRAINT [PK_PublisherReports]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'Publishers'
ALTER TABLE [Publishers]
ADD CONSTRAINT [PK_Publishers]
    PRIMARY KEY ([Id] );
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CongrReportId] in table 'PublisherReports'
ALTER TABLE [PublisherReports]
ADD CONSTRAINT [FK_PublisherReports_1_0]
    FOREIGN KEY ([CongrReportId])
    REFERENCES [CongregationReports]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublisherReports_1_0'
CREATE INDEX [IX_FK_PublisherReports_1_0]
ON [PublisherReports]
    ([CongrReportId]);
GO

-- Creating foreign key on [PublisherId] in table 'PublisherReports'
ALTER TABLE [PublisherReports]
ADD CONSTRAINT [FK_PublisherReports_0_0]
    FOREIGN KEY ([PublisherId])
    REFERENCES [Publishers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublisherReports_0_0'
CREATE INDEX [IX_FK_PublisherReports_0_0]
ON [PublisherReports]
    ([PublisherId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------