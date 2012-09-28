using System;
using System.Linq;

namespace SAIG.PS.Swampy.MongoDataAccess
{
    public interface ISession : IDisposable
    {
        IQueryable<T> All<T>();
        void Save<T>(T item) where T : class, new();
        void Drop<T>();
    }
}