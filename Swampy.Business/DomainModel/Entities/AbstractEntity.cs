using Swampy.Business.DomainModel.ValueObjects;

namespace Swampy.Business.DomainModel.Entities
{
    /// <summary>Base class for all entities</summary>
    public abstract class AbstractEntity
    {        
        public AbstractEntity()
        {
            this.ModificationDetails = new AuditInformation();
        }

        /// <summary>
        /// Entity Base class - all entities require an ID
        /// </summary>       
        public virtual int Id { get; protected set; }

        public virtual AuditInformation ModificationDetails { get; protected set; }
    }
}
