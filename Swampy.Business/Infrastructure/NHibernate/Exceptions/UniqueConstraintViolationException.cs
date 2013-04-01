using System;
using NHibernate.Exceptions;

namespace Swampy.Business.Infrastructure.NHibernate.Exceptions
{
    public class UniqueConstraintViolationException : ConstraintViolationException
    {
        public UniqueConstraintViolationException(string message, Exception innerException, string sql) : base(message, innerException, sql, null)
        {
            
        }
    }
}