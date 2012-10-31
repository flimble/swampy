using System;
using Swampy.Domain.Infrastructure.Swampy.Service.Infrastructure;
using log4net;

namespace Swampy.Domain.Infrastructure
{
    public class LogFactory : ILogFactory
    {
        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}


