using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAIG.PS.ConfigGen.Console
{
    public class TokenReplacer
    {
        public string Replace(string templateText, Dictionary<string, string> replacementValues)
        {
            var builder = new StringBuilder(templateText);

            foreach(var replacement in replacementValues)
            {
                builder.Replace(replacement.Key, replacement.Value);
            }

            return builder.ToString();

        }
    }
}
