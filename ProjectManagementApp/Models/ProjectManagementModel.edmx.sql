
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2011 17:18:42
-- Generated from EDMX file: C:\Users\John\Documents\wulab-prototype.net-a355bb6\ProjectManagementApp\Models\ProjectManagementModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Projmgmt];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserMicropost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Microposts] DROP CONSTRAINT [FK_UserMicropost];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProject] DROP CONSTRAINT [FK_UserProject_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProject] DROP CONSTRAINT [FK_UserProject_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectPhase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Phases] DROP CONSTRAINT [FK_ProjectPhase];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskTypeTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_TaskTypeTask];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskStatusTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_TaskStatusTask];
GO
IF OBJECT_ID(N'[dbo].[FK_PhaseTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_PhaseTask];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Microposts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Microposts];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Phases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phases];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[TaskTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskTypes];
GO
IF OBJECT_ID(N'[dbo].[TaskStatuses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskStatuses];
GO
IF OBJECT_ID(N'[dbo].[UserProject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProject];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [IsAdmin] bit  NOT NULL,
    [DateCreated] datetime  NOT NULL
);
GO

-- Creating table 'Microposts'
CREATE TABLE [dbo].[Microposts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [DateCreated] datetime  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Budget] decimal(18,0)  NOT NULL,
    [DateCreated] datetime  NOT NULL
);
GO

-- Creating table 'Phases'
CREATE TABLE [dbo].[Phases] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Budget] decimal(18,0)  NOT NULL,
    [DueDate] datetime  NULL,
    [StartDate] datetime  NULL,
    [FinishDate] datetime  NULL,
    [DateCreated] datetime  NOT NULL,
    [ProjectId] int  NOT NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Cost] decimal(18,0)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [PhaseId] int  NULL,
    [ProjectId] int  NOT NULL,
    [TaskTypeId] int  NOT NULL,
    [TaskStatusId] int  NOT NULL,
    [PhaseId1] int  NULL
);
GO

-- Creating table 'TaskTypes'
CREATE TABLE [dbo].[TaskTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TaskStatuses'
CREATE TABLE [dbo].[TaskStatuses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserProject'
CREATE TABLE [dbo].[UserProject] (
    [Users_Id] int  NOT NULL,
    [Projects_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Microposts'
ALTER TABLE [dbo].[Microposts]
ADD CONSTRAINT [PK_Microposts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Phases'
ALTER TABLE [dbo].[Phases]
ADD CONSTRAINT [PK_Phases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaskTypes'
ALTER TABLE [dbo].[TaskTypes]
ADD CONSTRAINT [PK_TaskTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaskStatuses'
ALTER TABLE [dbo].[TaskStatuses]
ADD CONSTRAINT [PK_TaskStatuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Users_Id], [Projects_Id] in table 'UserProject'
ALTER TABLE [dbo].[UserProject]
ADD CONSTRAINT [PK_UserProject]
    PRIMARY KEY NONCLUSTERED ([Users_Id], [Projects_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Microposts'
ALTER TABLE [dbo].[Microposts]
ADD CONSTRAINT [FK_UserMicropost]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMicropost'
CREATE INDEX [IX_FK_UserMicropost]
ON [dbo].[Microposts]
    ([UserId]);
GO

-- Creating foreign key on [Users_Id] in table 'UserProject'
ALTER TABLE [dbo].[UserProject]
ADD CONSTRAINT [FK_UserProject_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Projects_Id] in table 'UserProject'
ALTER TABLE [dbo].[UserProject]
ADD CONSTRAINT [FK_UserProject_Project]
    FOREIGN KEY ([Projects_Id])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject_Project'
CREATE INDEX [IX_FK_UserProject_Project]
ON [dbo].[UserProject]
    ([Projects_Id]);
GO

-- Creating foreign key on [ProjectId] in table 'Phases'
ALTER TABLE [dbo].[Phases]
ADD CONSTRAINT [FK_ProjectPhase]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectPhase'
CREATE INDEX [IX_FK_ProjectPhase]
ON [dbo].[Phases]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_ProjectTask]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTask'
CREATE INDEX [IX_FK_ProjectTask]
ON [dbo].[Tasks]
    ([ProjectId]);
GO

-- Creating foreign key on [TaskTypeId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_TaskTypeTask]
    FOREIGN KEY ([TaskTypeId])
    REFERENCES [dbo].[TaskTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskTypeTask'
CREATE INDEX [IX_FK_TaskTypeTask]
ON [dbo].[Tasks]
    ([TaskTypeId]);
GO

-- Creating foreign key on [TaskStatusId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_TaskStatusTask]
    FOREIGN KEY ([TaskStatusId])
    REFERENCES [dbo].[TaskStatuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskStatusTask'
CREATE INDEX [IX_FK_TaskStatusTask]
ON [dbo].[Tasks]
    ([TaskStatusId]);
GO

-- Creating foreign key on [PhaseId1] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_PhaseTask]
    FOREIGN KEY ([PhaseId1])
    REFERENCES [dbo].[Phases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PhaseTask'
CREATE INDEX [IX_FK_PhaseTask]
ON [dbo].[Tasks]
    ([PhaseId1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------