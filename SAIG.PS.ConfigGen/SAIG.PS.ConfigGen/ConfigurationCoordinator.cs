using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAIG.PS.ConfigGen.Interfaces;
using SAIG.PS.Swampy.Service;
using log4net;

namespace SAIG.PS.ConfigGen
{
    public class ConfigurationCoordinator
    {


        private readonly ITemplateReader _reader;
        private readonly ITokenReplacer _replacer;
        private readonly ITokenIdentifier _finder;
        private readonly IEndpointService _proxy; 
        private readonly ConfigWriter _writer;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ConfigurationCoordinator));

        public ConfigurationCoordinator(
            ITemplateReader reader, 
            ITokenReplacer replacer, 
            ITokenIdentifier finder, 
            IEndpointService  proxy, 
            ConfigWriter writer)
        {
            _reader = reader;
            _replacer = replacer;
            _finder = finder;
            _proxy = proxy;
            _writer = writer;
        }

        public void GenerateConfigs(string templatePath, string[] environmentname, string configSuffix, string appName, string targetpath)
        {
            
            _logger.DebugFormat("Starting Config Generation using template at {0}", templatePath);



            string templateText =
                _reader.Read(templatePath);


          
            _finder.SearchForTokens(templateText);
            var tokens = _finder.TokensFound;            

            
          

            foreach (string environment in environmentname)
            {
                var endpoints = _proxy.GetEndpoints(environment, tokens.ToArray());

                var keyvalueReplacement = endpoints.ToDictionary(x => x.Key, y => y.Value);

                string generatedConfigText = _replacer.Replace(templateText, keyvalueReplacement);

                string servername = _proxy.GetSingleEndpoint(environment, string.Format("{0}.ServerName", appName)).Value;

                string configName = string.Format("{0}.{1}.{2}", servername, environment, configSuffix);

                _writer.Write(targetpath, configName, generatedConfigText);
            }

        }
    }


}