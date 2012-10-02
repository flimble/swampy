using System;
using System.Linq;
using MongoDB.Driver;

namespace SAIG.PS.Swampy.MongoDataAccess
{
    public interface ISession : IDisposable
    {
        IQueryable<T> All<T>();
        IQueryable<T> FindAll<T>(Func<T, bool> predicate);

        IQueryable<T> Query<T>(IQueryObject<T> query);
        
        void Save<T>(T item) where T : class, new();
        void Drop<T>();
        T FindOne<T>(Func<T, bool> predicate);
    }
}