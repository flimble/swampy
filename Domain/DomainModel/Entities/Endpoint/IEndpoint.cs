namespace Swampy.Domain.Entities.Endpoint
{
    public interface IEndpoint
    {
        string Key { get; set; }
        string Description { get; set; }
        string Value { get; set; }
        string TypeName { get; }

        /// <summary>
        /// Entity Base class - all entities require an ID
        /// </summary>       
        int Id { get; }

        bool IsValid();
        bool Test();
        bool ContainsTokens(ITokenBuilder builder);
    }
}