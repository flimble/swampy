namespace Swampy.Domain.Contract
{
    public interface IEndpointAdministrator
    {
        //This should add the endpoint to all environments
        //Add a new endpoint and update all keys
        void CreateNewEndpointSetEnvironmentDefaults(string key, string value, string type, string description);

        //This should copy the endpoint skeleton to new Environment
        void CreateNewEnvironmentAndCopyDefaults(string environmentName);

        //Adds a global token to the service
        void CreateGlobalTokenForFindReplace(string key, string value);

    }
}
