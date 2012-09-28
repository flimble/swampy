using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;
using SAIG.PS.Swampy.Service.Entities.Endpoint;

namespace SAIG.PS.Swampy.Service.QueryObjects
{
    /// <summary>
    /// Spike of QueryObject in place of static Query class for IQueryable query encapsulation.
    /// Attempting to get away from the bloody repository pattern.... we'll see
    /// </summary>
    public class EndpointByEnvironmentNameQuery : IQueryObject<EndpointBase,Environment>
    {
        public string EnvironmentName { get; set;  }

        #region Implementation of IQueryObject<EndpointBase,Environment>

        public IQueryable<EndpointBase> GetQuery(IQueryable<Environment> inputQuery)
        {
            return inputQuery.First(x => x.Name == EnvironmentName).Endpoints.AsQueryable();
        }

        #endregion
    }
}
