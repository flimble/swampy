using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Swampy.Service.Entities
{
    /// <summary>Base class for all entities</summary>
    public abstract class EntityBase
    {        
        /// <summary>
        /// Entity Base class - all entities require an ID
        /// </summary>       
        public virtual Guid Id { get; protected set; }
    }
}
