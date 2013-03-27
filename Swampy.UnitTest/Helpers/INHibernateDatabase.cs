using System;
using NHibernate;

namespace Swampy.UnitTest.Helpers
{
    public interface INHibernateDatabase : IDisposable
    {
        ISession Session { get; set; }
        void BuildSchema();
    }
}