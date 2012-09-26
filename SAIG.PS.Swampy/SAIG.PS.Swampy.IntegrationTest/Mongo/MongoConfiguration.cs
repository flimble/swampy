using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SAIG.PS.Swampy.IntegrationTest.Mongo
{
    public static class MongoConfiguration
    {
        // private static fields
        private static MongoServer __testServer;
        private static MongoDatabase __testDatabase;
        private static MongoCollection<BsonDocument> __testCollection;

        // static constructor
        public static void Configure()
        {
            var connectionString = "mongodb://localhost/?safe=true"; // TODO: make this configurable

            var mongoUrlBuilder = new MongoUrlBuilder(connectionString);
            var serverSettings = mongoUrlBuilder.ToServerSettings();
            if (!serverSettings.SafeMode.Enabled)
            {
                serverSettings.SafeMode = SafeMode.True;
            }

            __testServer = MongoServer.Create(serverSettings);
            __testDatabase = __testServer["swampyunittests"];
            __testCollection = __testDatabase["testcollection"];
        }

        // public static methods
        /// <summary>
        /// Gets the test collection.
        /// </summary>
        public static MongoCollection<BsonDocument> TestCollection
        {
            get { return __testCollection; }
        }

        /// <summary>
        /// Gets the test database.
        /// </summary>
        public static MongoDatabase TestDatabase
        {
            get { return __testDatabase; }
        }

        /// <summary>
        /// Gets the test server.
        /// </summary>
        public static MongoServer TestServer
        {
            get { return __testServer; }
        }

        // public static methods
        /// <summary>
        /// Gets the test collection with a default document type of T.
        /// </summary>
        /// <typeparam name="T">The default document type.</typeparam>
        /// <returns>The collection.</returns>
        public static MongoCollection<T> GetTestCollection<T>()
        {
            return __testDatabase.GetCollection<T>(__testCollection.Name);
        }
    }
    
}
