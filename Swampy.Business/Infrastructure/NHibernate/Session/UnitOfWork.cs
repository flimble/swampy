using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Swampy.Business.Infrastructure.NHibernate.Session
{

    public static class UnitOfWork
    {
        public static void Initialize(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        private static ISessionFactory SessionFactory;

        public static ISession GetCurrentSession
        {
            get { return SessionFactory.GetCurrentSession(); }
        }
    }

}
