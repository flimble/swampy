﻿using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.DomainModel.Queries
{
    public class EndpointQuery
    {
        public string EndpointName { get; set; }
        public string EnvironmentName { get; set; }

        public IQueryable<ConfigurationItem> Query(ISession session)
        {
            var result =
                from e in
                    session.Query<SwampyEnvironment>()
                           .Where(en => en.Name == EnvironmentName)
                           .SelectMany(en => en.ConfigurationItems, (ep, r) => r)
                           .Where(endpoint => endpoint.Key == EndpointName)
                select e;

            return result;

        }
    }
}