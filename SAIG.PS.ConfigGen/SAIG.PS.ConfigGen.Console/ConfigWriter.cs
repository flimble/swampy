using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SAIG.PS.ConfigGen.Console
{
    public class ConfigWriter
    {
        public void Write(string path, string serverName, string environmentName, string fileText)
        {
            string configPath = Path.Combine(path, ConfigFileName(serverName, environmentName));

            File.WriteAllText(path, configPath);   
        }

        protected string ConfigFileName(string serverName, string environmentName)
        {
            return string.Format("{0}.{1}.config", serverName, environmentName);
        }
    }
}
