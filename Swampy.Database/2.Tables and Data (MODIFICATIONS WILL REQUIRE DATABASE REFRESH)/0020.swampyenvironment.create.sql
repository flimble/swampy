    create table [SwampyEnvironment] (
        SwampyEnvironmentId INT not null,
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



    insert into NHibernateHiLoIdentity values ( 1,'SwampyEnvironment' )