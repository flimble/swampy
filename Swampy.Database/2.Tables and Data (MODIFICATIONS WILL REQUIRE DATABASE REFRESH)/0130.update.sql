
    create table NHibernateHiLoIdentity (
         NextHigh INT,
       TableKey VARCHAR(125)

    )

    insert into NHibernateHiLoIdentity values ( 1,'ConfigurationItem' )
    insert into NHibernateHiLoIdentity values ( 1,'SwampyEnvironment' )