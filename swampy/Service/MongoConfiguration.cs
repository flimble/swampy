using System;
using System.Linq;
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using Swampy.Service.Entities;
using Swampy.Service.Entities.Endpoint;

namespace Swampy.Service
{
    public static class MongoConfiguration
    {
        public static void Configure()
        {
            //originally planned to use this to autogenerate. leaving out for now and will retry later

            BsonSerializer.RegisterIdGenerator(
            typeof(Guid),
            GuidGenerator.Instance
            );
            
            new DefaultAbstractClassRegistrator().RegisterSubClasses<EntityBase>();
            
        }

        
    }

    public class DefaultAbstractClassRegistrator
    {
        public void RegisterSubClasses<T>()
        {
            var entities = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(T)) && !x.IsAbstract)
                .Select(x => x)
                .ToList();

            foreach (Type concreteEntityType in entities)
            {
                MethodInfo method = typeof(DefaultAbstractClassRegistrator).GetMethod("RegisterIfNotAlreadyDone", new Type[0]);
                MethodInfo generic = method.MakeGenericMethod(concreteEntityType);
                generic.Invoke(null, new object[0]);
            }
        }

        public static void RegisterIfNotAlreadyDone<T>() where T : EntityBase
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
            {
                BsonClassMap.RegisterClassMap<T>(cm => cm.AutoMap());
            }
        }
    }
}
