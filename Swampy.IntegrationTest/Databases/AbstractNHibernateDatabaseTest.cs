using System;
using NHibernate;
using NUnit.Framework;

namespace Swampy.UnitTest.Helpers
{
    [TestFixture]
    public class AbstractNHibernateDatabaseTest 
    {
        private readonly NHibernateInMemoryDatabase _inMemoryDatabase;        
        private readonly TheDatabase _databaseLifetime;

        public ISession Session { get { return _inMemoryDatabase.Session; } }

        public AbstractNHibernateDatabaseTest() : this(TheDatabase.MustBeFresh) { }

        public AbstractNHibernateDatabaseTest(TheDatabase databaseLifeTime)
        {
            _inMemoryDatabase = new NHibernateInMemoryDatabase();
            _databaseLifetime = databaseLifeTime;
                    
        }

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            if (_databaseLifetime.HasFlag(TheDatabase.CanBeDirty))
            {
                _inMemoryDatabase.BuildSchema();
            }
        }

        [SetUp]
        public void SetUp()
        {
            if (_databaseLifetime.HasFlag(TheDatabase.MustBeFresh))
            {             
               _inMemoryDatabase.Dispose();
               _inMemoryDatabase.BuildSchema();
            }
                
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _inMemoryDatabase.Dispose();
        }
    }

    [Flags]
    public enum TheDatabase
    {
        CanBeDirty = 0,
        MustBeFresh = 1
    }


}


