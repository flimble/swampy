using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NUnit.Framework;
using Swampy.Admin.Web.App_Start;
using Swampy.UnitTest.Helpers;

namespace Swampy.IntegrationTest
{
    public class DatabaseSchemaHealthCheck
    {
        [Test]
        [Explicit]
        public void check_nhibernate_mappings_against_sql_server_database()
        {
            NHibernateConfig.Configure();

            using (ISession session = NHibernateConfig.SessionFactory.OpenSession())
            {
                var allClassMetadata = NHibernateConfig.SessionFactory.GetAllClassMetadata();
                foreach (var entry in allClassMetadata)
                {

                    session.CreateCriteria(entry.Key).SetMaxResults(0).List();
                }
            }
        }
    }
}
