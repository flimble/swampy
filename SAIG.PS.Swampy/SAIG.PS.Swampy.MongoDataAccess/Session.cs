using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace SAIG.PS.Swampy.MongoDataAccess
{
  
        /*
class Session:IDisposable
    {
        
        MongoQueryProvider _provider;
        public Session()
        {
            _provider=new MongoQueryProvider("test");
        }
        public MongoQueryProvider Provider {
            get {
                return _provider;
            }
        }
       

        public T MapReduce<T>(string map, string reduce) {
            T result = default(T);
            using (var mr = _provider.Server.CreateMapReduce()) {
                var response = mr.Execute(new MapReduceOptions(typeof(T).Name) { Map = map, Reduce = reduce });
                var coll = response.GetCollection<MapReduceResult>();
                var r = coll.Find().FirstOrDefault();
                result = (T)r.Value;
            }
            return result;
        }

        public void Add<T>(T item) where T : class, new()
        {
            _provider.DB.GetCollection<T>().Insert(item);
        }

        public void Update<T>(T item) where T : class, new()
        {
            _provider.DB.GetCollection<T>().UpdateOne(item, item);
        }

        public void Drop<T>()
        {
            _provider.DB.DropCollection(typeof (T).Name);
        }

        public void Dispose() {
            _provider.Server.Dispose();
        }

    }
        */
}
