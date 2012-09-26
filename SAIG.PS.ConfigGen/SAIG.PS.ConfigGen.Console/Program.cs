using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NDesk.Options;
using SAIG.PS.ConfigGen.Interfaces;
using SAIG.PS.Swampy.Service;
using SAIG.PS.Swampy.UnitTest.Fakes;
using log4net;

namespace SAIG.PS.ConfigGen.Console
{
    public class Program
    {
        private static ILog _logger; 
        private static IWindsorContainer _container;

        /// <summary>
        /// Uses NDesk for commandline parsing.
        /// </summary>
        /// <seealso cref="www.ndesk.org"/>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            _logger = LogManager.GetLogger(typeof (Program));

            _logger.Debug(String.Join(",", args));            

            ConfigureIOC();

            bool helpRequested = false;
            string configSuffix = "config";

            string template = null, outdir = null, application = null;
            string[] environments = null;

            var p = new OptionSet()
                {
                    {"help|?", "show this message and exit", h => helpRequested = (h != null) },
                    {"template=", "The config template file", t => template = t},
                    {"outdir=", "The output directory folder name for created configs", o => outdir = o},
                    {"environments=", "Comma separated list of environment names e.g. 'QA1,QA2'", e => environments = e.Split(',')},
                    {"applicationName=", "Name of application for which config is generated", a => application = a },
                    {"configName=", "Optional config suffix name to override default value 'config'",  c => configSuffix = c}
                };
                
               p.Parse(args);

            if(helpRequested)
                ShowHelp(p);

            

            if(String.IsNullOrEmpty(template))
                throw new ArgumentNullException(template);

            if (String.IsNullOrEmpty(outdir))
                throw new ArgumentNullException(outdir);

            if (String.IsNullOrEmpty(application))
                throw new ArgumentNullException(application);



            var engine = _container.Resolve<ConfigurationCoordinator>();

            engine.GenerateConfigs(template, environments, configSuffix, application, outdir);

        }

        private static void ShowHelp(OptionSet p)
        {
            p.WriteOptionDescriptions(System.Console.Out);
        }

        private static void ConfigureIOC()
        {
            _logger.Debug("Configuring IOC");

            _container = new WindsorContainer();
            _container.Register(
                Component.For<ITemplateReader>().ImplementedBy<TemplateReader>(), 
                Component.For<ITokenIdentifier>().ImplementedBy<TokenIdentifier>(), 
                Component.For<ITokenReplacer>().ImplementedBy<TokenReplacer>(),
                Component.For<ConfigWriter>().ImplementedBy<ConfigWriter>(),
                Component.For<IEndpointService>().ImplementedBy<FakeEndpointService>(),
                Component.For<ConfigurationCoordinator>().ImplementedBy<ConfigurationCoordinator>()
                );

        }

    }
}
