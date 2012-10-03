using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SAIG.PS.Swampy.MongoDataAccess;

namespace SAIG.PS.Swampy.Service
{
    public static class CastleConfiguration
    {


        public static void Configure()
        {

            var container = new WindsorContainer();
            container.Register(
                Component.For<ISession>()
                .ImplementedBy<Session>()
                .DependsOn(Property.ForKey("MongoServer").Eq("connectionString"))
                .DependsOn(Property.ForKey("MongoDatabase").Eq("databaseName"))
                );

            container.Install(Configuration.FromAppConfig());
        }
    }
}
