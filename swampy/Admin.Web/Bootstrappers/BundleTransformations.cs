using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Swampy.Admin.Web.Bootstrappers
{

    public class LessTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }


    public class CoffeeTransform : JsMinify, IBundleTransform
    {
        public override void Process(BundleContext context, BundleResponse response)
        {
            var coffeeScriptEngine = new CoffeeSharp.CoffeeScriptEngine();
            string compiledCoffeeScript = String.Empty;
            foreach (var file in response.Files)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    compiledCoffeeScript += coffeeScriptEngine.Compile(reader.ReadToEnd());
                    reader.Close();
                }
            }
            response.Content = compiledCoffeeScript;
            base.Process(context, response);
        }
    }
}