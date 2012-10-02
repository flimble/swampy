using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAIG.PS.Swampy.MongoDataAccess
{
    public abstract class QueryBase<T> : IQueryObject<T>
    {
        public abstract IQueryable<T> GetQuery();

        public virtual void SetSession(ISession currentSession)
        {
            Session = currentSession;
        }

        protected virtual ISession Session { get; set; }


    }
}
