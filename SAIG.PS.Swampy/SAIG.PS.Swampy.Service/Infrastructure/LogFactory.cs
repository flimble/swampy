using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAIG.PS.Swampy.Service.Infrastructure.SAIG.PS.Swampy.Service.Infrastructure;
using log4net;

namespace SAIG.PS.Swampy.Service.Infrastructure
{
    public class LogFactory : ILogFactory
    {
        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}


