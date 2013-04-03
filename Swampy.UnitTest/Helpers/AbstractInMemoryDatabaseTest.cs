
using System;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Swampy.Business.Infrastructure.NHibernate;
using Swampy.UnitTest.Helpers;

namespace Swampy.UnitTest.Queries
{
    public class AbstractInMemoryDatabaseTest 
    {
        private NHibernateInMemoryDatabase _inMemoryDatabase;        

        private readonly bool _clearDataAfterEveryTest;

        public ISession session { get { return _inMemoryDatabase.Session; } }

        public AbstractInMemoryDatabaseTest() : this(true) { }

        public AbstractInMemoryDatabaseTest(bool clearDataAfterEveryTest)
        {
            _inMemoryDatabase = new NHibernateInMemoryDatabase();
            _clearDataAfterEveryTest = clearDataAfterEveryTest;
            

            if (!_clearDataAfterEveryTest)
                _inMemoryDatabase.BuildSchema();

            
        }


        [SetUp]
        public void SetUp()
        {
            if (_clearDataAfterEveryTest)
                _inMemoryDatabase.BuildSchema();
        }

        [TearDown]
        public void TearDown()
        {
            if (_clearDataAfterEveryTest)
                _inMemoryDatabase.Dispose();
        }
    }
}
