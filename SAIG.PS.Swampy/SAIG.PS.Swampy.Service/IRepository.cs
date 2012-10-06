using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Environment=SAIG.PS.Swampy.Service.Entities.Environment;

namespace SAIG.PS.Swampy.MongoDataAccess
{
    public interface IRepository
    {
        void AddNewEnvironment(Environment environment);

    }
}
