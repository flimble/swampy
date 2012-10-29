using System;
using Swampy.Shared.Infrastructure.Swampy.Service.Infrastructure;
using log4net;

namespace Swampy.Shared.Infrastructure
{
    public class LogFactory : ILogFactory
    {
        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}


