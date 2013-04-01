using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Exceptions;
using Swampy.Business.Infrastructure.NHibernate.Exceptions;

namespace Swampy.Business.Infrastructure.NHibernate
{
    public class MsSqlExceptionConverter : ISQLExceptionConverter
    {
        public Exception Convert(AdoExceptionContextInfo exInfo)
        {
            var sqle = ADOExceptionHelper.ExtractDbException(exInfo.SqlException) as SqlException;
            if (sqle != null)
            {
                switch (sqle.Number)
                {
                    case 547:
                        return new ConstraintViolationException(exInfo.Message,
                                                                sqle.InnerException, exInfo.Sql, null);
                    case 208:
                        return new SQLGrammarException(exInfo.Message,
                                                       sqle.InnerException, exInfo.Sql);
                    case 3960:
                        return new StaleObjectStateException(exInfo.EntityName, exInfo.EntityId);

                    case 2627:
                        return new UniqueConstraintViolationException(exInfo.Message, sqle.InnerException, exInfo.Sql);
                }
            }
            return SQLStateConverter.HandledNonSpecificException(exInfo.SqlException,
                                                                 exInfo.Message, exInfo.Sql);
        }
    }
}


