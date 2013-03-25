using System;
using log4net;

namespace Swampy.Business.Infrastructure.Logging
{
    namespace Swampy.Service.Infrastructure
    {
        public interface ILogFactory
        {
            ILog GetLogger(Type type);
        }
    }
}
