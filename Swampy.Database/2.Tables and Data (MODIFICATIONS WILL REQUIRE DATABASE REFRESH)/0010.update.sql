
    create table [ConfigurationItem] (
        ConfigurationItemId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Value NVARCHAR(255) not null,
       ConfigurationType NVARCHAR(255) not null,
       StoreAsToken BIT not null,
       primary key (ConfigurationItemId)
    )
    create table [SwampyEnvironment] (
        SwampyEnvironmentId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Domain NVARCHAR(255) not null,
       primary key (SwampyEnvironmentId)
    )
    create table [SwampyServer] (
        SwampyServerId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       primary key (SwampyServerId)
    )
    alter table [ConfigurationItem] 
        add constraint FK_ConfigurationItem_SwampyEnvironment 
        foreign key (ConfigurationItemId) 
        references [SwampyEnvironment]
    alter table [SwampyServer] 
        add constraint FK_SwampyServer_SwampyEnvironment 
        foreign key (SwampyServerId) 
        references [SwampyEnvironment]