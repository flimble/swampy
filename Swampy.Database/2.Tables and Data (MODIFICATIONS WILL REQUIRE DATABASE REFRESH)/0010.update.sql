
    create table [ConfigurationItem] (
        ConfigurationItemId INT IDENTITY NOT NULL,
       Key NVARCHAR(255) null,
       Value NVARCHAR(255) null,
       Type NVARCHAR(255) null,
       StoreAsToken BIT null,
       primary key (ConfigurationItemId)
    )
    create table [SwampyEnvironment] (
        SwampyEnvironmentId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null unique,
       Domain NVARCHAR(255) null,
       primary key (SwampyEnvironmentId)
    )
    create table [SwampyServer] (
        SwampyServerId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
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