
    alter table [ConfigurationItem] 
        add ModifiedOn DATETIME
    alter table [ConfigurationItem] 
        add ModifiedBy NVARCHAR(255)
    alter table [SwampyEnvironment] 
        add ModifiedOn DATETIME
    alter table [SwampyEnvironment] 
        add ModifiedBy NVARCHAR(255)
    alter table [SwampyServer] 
        add ModifiedOn DATETIME
    alter table [SwampyServer] 
        add ModifiedBy NVARCHAR(255)