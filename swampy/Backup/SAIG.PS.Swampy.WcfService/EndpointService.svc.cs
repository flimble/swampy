using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service;
using SAIG.PS.Swampy.Service.Contract;
using SAIG.PS.Swampy.Service.DomainServices;

namespace SAIG.PS.Swampy.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class EndpointService : IEndpointService
    {
        protected IEndpointService domainService;

        #region Implementation of IEndpointService
        public EndpointService()
        {
            MongoConfiguration.Configure();
            string connectionString = ConfigurationManager.AppSettings["MongoServer"];
            string databaseName = ConfigurationManager.AppSettings["MongoDatabase"];
            domainService = new SwampyEndpointService(new Session(connectionString, databaseName));
        }


        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {
            return domainService.GetEndpoints(environment, keys, callingApplication);
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            return domainService.GetSingleEndpoint(environment, key, callingApplication);
        }

        #endregion
    }
}
