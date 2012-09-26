using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace SAIG.PS.Swampy.Service.Infrastructure
{
    namespace SAIG.PS.Swampy.Service.Infrastructure
    {
        public interface ILogFactory
        {
            ILog GetLogger(Type type);
        }
    }
}
