using System;
using log4net;

namespace Swampy.Domain.Infrastructure
{
    namespace Swampy.Service.Infrastructure
    {
        public interface ILogFactory
        {
            ILog GetLogger(Type type);
        }
    }
}
