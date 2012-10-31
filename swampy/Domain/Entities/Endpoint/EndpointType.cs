namespace Swampy.Domain.Entities.Endpoint
{
    /// <summary>
    /// Enumeration of available types of endpoints
    /// NOTE: This may be replaced by simplifying casting from db straight to types / using a typename in the endpoint entity
    /// </summary>
    enum EndpointType
    {
        Basic=0,
        SqlConnectionString=1,
        WebUrl=2,
        ServiceUrl=3
    }
}
