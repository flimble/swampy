using Swampy.Business.Contract;

namespace Swampy.UnitTest.Service.Fakes
{
    public class FakeEndpointService : ISwampyEndpointService
    {
        #region Implementation of IEndpointService

        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {
            if (environment == "SIT1")
                return SIT1Endpoints();

            if (environment == "SIT2")
                return SIT2Endpoints();

            return null;
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            if (environment == "SIT1")
                return new KeyPair("QVAS.ServerName", "ausydhq-pstap08");

            if (environment == "SIT2")
                return new KeyPair("QVAS.ServerName", "ausydhq-pstap10");

            return null;
        
        }


        private KeyPair[] SIT1Endpoints()
        {
            return new[]
                       {
                           new KeyPair("CSM.ModeKey","SIT1"),
                           new KeyPair("CSM.CommonDBConnectionString",@"SIT1ConnectionString"),
                           new KeyPair("QVAS.CommonDBConnectionString",@"SIT1ConnectionString"),
                           new KeyPair("QVAS.ModeKey","SIT1"),
                           new KeyPair("QVAS.Servername", "SIT1")
                       };
        }

        private KeyPair[] SIT2Endpoints()
        {
            return new[]
                       {
                           new KeyPair("CSM.ModeKey","SIT2"),
                           new KeyPair("CSM.CommonDBConnectionString",@"SIT2ConnectionString"),
                           new KeyPair("QVAS.CommonDBConnectionString",@"SIT2ConnectionString"),
                           new KeyPair("QVAS.ModeKey","SIT2"),
                           new KeyPair("QVAS.Servername", "SIT2")
                       };
        }
        #endregion
    }
}
