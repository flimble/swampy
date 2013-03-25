namespace Swampy.Business.DomainModel.Entities
{
    /// <summary>Base class for all entities</summary>
    public abstract class AbstractEntity
    {        
        /// <summary>
        /// Entity Base class - all entities require an ID
        /// </summary>       
        public virtual int Id { get; protected set; }
    }
}
