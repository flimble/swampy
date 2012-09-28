namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    /// <summary>
    /// Interface for validating text of an entity
    /// </summary>
    public interface IEndpointValidator
    {
        bool IsValid(string endpoint);
    }
}