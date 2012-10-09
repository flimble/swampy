using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NDesk.Options;
using SAIG.PS.ConfigGen.Interfaces;
using log4net;

namespace SAIG.PS.ConfigGen.Console
{
    public class Program
    {
        private static IWindsorContainer _container;

        /// <summary>
        /// Uses NDesk for commandline parsing.
        /// </summary>
        /// <seealso cref="www.ndesk.org"/>
        /// <param name="args"></param>
        public static int Main(string[] args)
        {
            ConfigureIOC();

            try
            {
                var runner = new Runner(_container.Resolve<ConfigurationCoordinator>());
                runner.Run(args);

                return (int) ExitCode.Success;
            }
            catch (Exception)
            {
                return (int) ExitCode.Failure;
            }                       
        }

      

        private static void ConfigureIOC()
        {
            _container = new WindsorContainer();
            _container.Register(
                Component.For<ITemplateReader>().ImplementedBy<TemplateReader>(), 
                Component.For<ITokenIdentifier>().ImplementedBy<TokenIdentifier>(), 
                Component.For<ITokenReplacer>().ImplementedBy<TokenReplacer>(),
                Component.For<ConfigWriter>().ImplementedBy<ConfigWriter>(),
                Component.For<IEnvironmentServiceProxy>().ImplementedBy<EnvironmentServiceProxy>(),
                Component.For<ConfigurationCoordinator>().ImplementedBy<ConfigurationCoordinator>()
                );

        }

    }
}
