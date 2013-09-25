using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using Swampy.Business.Infrastructure.NHibernate;

namespace Swampy.Service
{
    public sealed class NHibernateWcfContextInitializer : IDispatchMessageInspector
    {
        private static readonly ISessionFactory sessionFactory = BuildSessionFactory();

        private static ISessionFactory BuildSessionFactory()
        {
            var sqlServerConfiguration = MsSqlConfiguration.MsSql2008
                                                           .ConnectionString(
                                                               x =>
                                                               x.Server(@".\local")
                                                                .TrustedConnection()
                                                                .Database("Swampy"))
                                                           .ShowSql();








               return NHibernateConfigurationFactory.Configuration(sqlServerConfiguration)
                   .BuildConfiguration()                    
                   .CurrentSessionContext<WcfOperationSessionContext>()
                   .BuildSessionFactory();
                

        }

        
           

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var session = sessionFactory.OpenSession();

            session.BeginTransaction();
            CurrentSessionContext.Bind(
             session
             );            
            return null;

            
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {           
            using (var session = CurrentSessionContext.Unbind(sessionFactory))
            {
                if (session == null)
                    return;

                if (!session.Transaction.IsActive)
                    return;

                try
                {
                    session.Transaction.Commit();
                }
                catch
                {
                    session.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    session.Close();
                }
            }

        }
    }
}
