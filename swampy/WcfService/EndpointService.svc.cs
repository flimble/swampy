using Swampy.RavenDataAccess;
using Swampy.Service.Contract;

namespace Swampy.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class EndpointService : IEndpointService
    {
        protected IEndpointService domainService;

        #region Implementation of IEndpointService
        public EndpointService()
        {
            /*MongoConfiguration.Configure();
            string connectionString = ConfigurationManager.AppSettings["MongoServer"];
            string databaseName = ConfigurationManager.AppSettings["MongoDatabase"];*/



            DataDocumentStore.Initialize();
            //domainService = new SwampyEndpointService((connectionString, databaseName));
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
