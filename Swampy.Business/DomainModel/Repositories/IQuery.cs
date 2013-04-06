using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Swampy.Business.DomainModel.Repositories
{
    public interface IQuery<out TResult>
    {
        IQueryable<TResult> Execute(ISession session);
    }

}
