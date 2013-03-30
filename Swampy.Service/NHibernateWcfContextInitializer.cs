using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace Swampy.Service
{
    public sealed class NHibernateWcfContextInitializer : IDispatchMessageInspector
    {
        private static readonly ISessionFactory sessionFactory = BuildSessionFactory();

        private static ISessionFactory BuildSessionFactory()
        {
            return new Configuration()
                .Configure()
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
