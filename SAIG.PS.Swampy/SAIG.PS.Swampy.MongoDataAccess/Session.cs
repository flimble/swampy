using System;
using System.Linq;
using MongoDB.Driver;
using SAIG.PS.Swampy.Shared.Infrastructure.Extensions;

namespace SAIG.PS.Swampy.MongoDataAccess
{

    /// <summary>
    /// Basic Session/Datacontext style class for access to the Mongo Database.
    /// Not strictly a Session as there is no support for transactional chaining
    /// </summary>
    public class Session : ISession
    {

        private MongoServer _server;
        private MongoDatabase _database;

        protected internal MongoServer Server
        {
            get { return _server; }
        }


        public Session(string connectionString, string databaseName)
        {
            var mongoUrlBuilder = new MongoUrlBuilder(connectionString);

            _server = new MongoServer(mongoUrlBuilder.ToServerSettings());
            _database = _server.GetDatabase(databaseName);
        }


        public T MapReduce<T>(string map, string reduce)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All<T>()
        {
            return GetCollection<T>().FindAllAs<T>().AsQueryable();
        }

        protected MongoCollection<T> GetCollection<T>(string collectionName = null)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                Type g = typeof(T);
                collectionName = g.Name.SingularToPlural();
            }

            return _database.GetCollection<T>(collectionName);
        }


        public void Add<T>(T item) where T : class, new()
        {
            GetCollection<T>().Insert(item);
        }

        public void Save<T>(T item) where T : class, new()
        {
            GetCollection<T>().Save(item);
        }

        public void Drop<T>()
        {
            _database.DropCollection(typeof(T).Name);
        }

        public void Dispose()
        {
            _server = null;
            _database = null;
        }

    }

}
