using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using SAIG.PS.Swampy.Service.Infrastructure.SAIG.PS.Swampy.Service.Infrastructure;
using log4net;

namespace SAIG.PS.Swampy.Service.Infrastructure
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
                    message = String.Format("{0}.{1}({2})",
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
