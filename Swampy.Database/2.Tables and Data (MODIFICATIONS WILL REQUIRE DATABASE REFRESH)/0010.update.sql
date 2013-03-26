
    alter table [ConfigurationItem] 
        add SwampyEnvironment_id INT
    alter table [SwampyEnvironment] 
        add Domain NVARCHAR(255)
    alter table [SwampyServer] 
        add SwampyEnvironment_id INT
    alter table [ConfigurationItem] 
        add constraint FK_ConfigurationItem_SwampyEnvironment 
        foreign key (SwampyEnvironment_id) 
        references [SwampyEnvironment]
    alter table [SwampyServer] 
        add constraint FK_SwampyServer_SwampyEnvironment 
        foreign key (SwampyEnvironment_id) 
        references [SwampyEnvironment]
    create index IDX_Server_Name on [SwampyServer] (Name, SwampyEnvironment_id)