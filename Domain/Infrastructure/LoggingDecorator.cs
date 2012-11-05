using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Swampy.Domain.Contract;
using Swampy.Domain.DomainServices;

namespace Swampy.Domain.Infrastructure
{
    /// <summary>
    /// Decorate an existing class to add logging using LoggingInterceptor.
    /// </summary>
    public static class LoggingDecorator
    {
        public static T Decorate<T>(T concreteType) where T : class
        {
            var result = new ProxyGenerator()
                .CreateInterfaceProxyWithTargetInterface<T>(
                        concreteType,
                    new LoggingInterceptor(
                    new LogFactory()
                  ));

            return result;
        }
    }
}
