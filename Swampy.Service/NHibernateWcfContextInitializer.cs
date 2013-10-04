using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using Swampy.Business.Infrastructure.NHibernate;
using Swampy.Business.Infrastructure.NHibernate.Session;

namespace Swampy.Service
{
    public sealed class NHibernateWcfContextInitializer : IDispatchMessageInspector
    {
        private static ISessionFactory SessionFactory;

        public NHibernateWcfContextInitializer()
        {
            SessionFactory = BuildSessionFactory();
            UnitOfWork.Initialize(SessionFactory);
        }
        
        

        private static ISessionFactory BuildSessionFactory()
        {         

            var sqlServerConfiguration = MsSqlConfiguration.MsSql2008
                                                           .ConnectionString(
                                                               x =>
                                                               x.FromConnectionStringWithKey("SwampyDatabase"))
                                                           .ShowSql();








               return NHibernateConfigurationFactory.Configuration(sqlServerConfiguration)
                   .BuildConfiguration()                    
                   .CurrentSessionContext<WcfOperationSessionContext>()
                   .BuildSessionFactory();
                

        }

        
           

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var session = SessionFactory.OpenSession();

            session.BeginTransaction();
            CurrentSessionContext.Bind(
             session
             );            
            return null;

            
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {           
            using (var session = CurrentSessionContext.Unbind(SessionFactory))
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
