using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace SAIG.PS.Swampy.Service.Entities
{
    /// <summary>Base class for all entities</summary>
    public abstract class EntityBase
    {
        //TODO: Investigate if there is a way to make entities Mongo agnostic.
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]       
        public virtual string Id { get; protected set; }
    }
}
