using System;
using log4net;

namespace Swampy.Shared.Infrastructure
{
    namespace Swampy.Service.Infrastructure
    {
        public interface ILogFactory
        {
            ILog GetLogger(Type type);
        }
    }
}
