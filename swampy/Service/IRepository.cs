using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Environment=Swampy.Service.Entities.Environment;

namespace Swampy.MongoDataAccess
{
    public interface IRepository
    {
        void AddNewEnvironment(Environment environment);

    }
}
