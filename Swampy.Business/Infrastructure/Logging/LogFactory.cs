using System;
using Swampy.Business.Infrastructure.Logging.Swampy.Service.Infrastructure;
using log4net;

namespace Swampy.Business.Infrastructure.Logging
{
    public class LogFactory : ILogFactory
    {
        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}


