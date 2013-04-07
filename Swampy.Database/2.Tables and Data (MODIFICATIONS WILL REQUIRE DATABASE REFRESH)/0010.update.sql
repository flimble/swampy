
    create table [ConfigurationItem] (
        ConfigurationItemId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Value NVARCHAR(255) not null,
       ConfigurationType NVARCHAR(255) not null,
       StoreAsToken BIT not null,
       ModifiedOn DATETIME not null,
       ModifiedBy NVARCHAR(255) not null,
       SwampyEnvironmentId INT null,
       primary key (ConfigurationItemId)
    )
    create table [SwampyEnvironment] (
        SwampyEnvironmentId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null unique,
       Domain NVARCHAR(255) not null,
       Description NVARCHAR(255) null,
       ModifiedOn DATETIME not null,
       ModifiedBy NVARCHAR(255) not null,
       primary key (SwampyEnvironmentId)
    )
    alter table [ConfigurationItem] 
        add constraint FK_ConfigurationItem_SwampyEnvironment 
        foreign key (SwampyEnvironmentId) 
        references [SwampyEnvironment]