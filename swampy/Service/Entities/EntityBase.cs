namespace Swampy.Service.Entities
{
    /// <summary>Base class for all entities</summary>
    public abstract class EntityBase
    {        
        /// <summary>
        /// Entity Base class - all entities require an ID
        /// </summary>       
        public virtual string Id { get; protected set; }
    }
}
