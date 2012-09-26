using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace SAIG.PS.Swampy.Service
{
    public abstract class EntityBase
    {
        //[BsonId(IdGenerator = typeof(StringObjectIdGenerator))] 
        public virtual object Id { get; set; }
    }
}
