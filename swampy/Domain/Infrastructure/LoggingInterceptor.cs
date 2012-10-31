using System;
using System.Linq;
using Castle.DynamicProxy;
using Swampy.Shared.Infrastructure;
using Swampy.Shared.Infrastructure.Swampy.Service.Infrastructure;
using log4net;

namespace Swampy.Domain.Infrastructure
{
    /// <summary>
    /// Generic AOP Logging Interceptor using DynamicProxy 
    /// In large part lifted from following blog article 
    /// http://ayende.com/blog/3474/logging-the-aop-way
    /// </summary>
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogFactory _factory;

        public LoggingInterceptor(ILogFactory factory)
        {
            _factory = factory;
        }

        public void Intercept(IInvocation invocation)
        {
            ILog logger = _factory.GetLogger(invocation.TargetType);
            try
            {
                string message = null;
                if (logger.IsDebugEnabled)
                {
                    message = String.Format("{0}-{1}.{2}({3})",
                                                   SystemTime.Now,
                                                   invocation.TargetType.FullName,
                                                   invocation.Method,
                                                   String.Join(", ", invocation.Arguments.ToArray()));
                        

                    logger.Debug(message);
                }

                invocation.Proceed();
                if (logger.IsDebugEnabled)
                {

                    logger.Debug("Result of " + message + " is: " + invocation.ReturnValue);
                }
            }
            catch (Exception e)
            {
               logger.Error(e);
                throw;
            }
        }
    }
}
