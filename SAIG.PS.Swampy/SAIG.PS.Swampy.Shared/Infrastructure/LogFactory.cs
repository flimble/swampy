using System;
using SAIG.PS.Swampy.Shared.Infrastructure.SAIG.PS.Swampy.Service.Infrastructure;
using log4net;

namespace SAIG.PS.Swampy.Shared.Infrastructure
{
    public class LogFactory : ILogFactory
    {
        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}


