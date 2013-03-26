using Castle.DynamicProxy;

namespace Swampy.Business.Infrastructure.Logging
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
