
    alter table [ConfigurationItem] 
        add Key NVARCHAR(255)
    alter table [SwampyEnvironment] 
        add Domain NVARCHAR(255)
    alter table [ConfigurationItem] 
        add constraint FK_ConfigurationItem_SwampyEnvironment 
        foreign key (ConfigurationItemId) 
        references [SwampyEnvironment]
    alter table [SwampyServer] 
        add constraint FK_SwampyServer_SwampyEnvironment 
        foreign key (SwampyServerId) 
        references [SwampyEnvironment]