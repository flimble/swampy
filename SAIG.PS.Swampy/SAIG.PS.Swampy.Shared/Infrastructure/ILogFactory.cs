using System;
using log4net;

namespace SAIG.PS.Swampy.Shared.Infrastructure
{
    namespace SAIG.PS.Swampy.Service.Infrastructure
    {
        public interface ILogFactory
        {
            ILog GetLogger(Type type);
        }
    }
}
