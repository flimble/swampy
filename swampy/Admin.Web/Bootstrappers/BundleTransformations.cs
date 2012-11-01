using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Optimization;
using dotless.Core;
using dotless.Core.Abstractions;
using dotless.Core.Importers;
using dotless.Core.Input;
using dotless.Core.Loggers;
using dotless.Core.Parser;

namespace Swampy.Admin.Web.Bootstrappers
{
    /*/// <summary>
    /// The bundle transform used to minify JS files by using YUI Compressor for .Net.
    /// </summary>
    public class YuiJsMinify : IBundleTransform
    {
        /// <summary>
        /// Processes the specified bundle of JS files.
        /// </summary>
        /// <param name="bundle">The JS bundle.</param>
        public virtual void Process(BundleResponse bundle)
        {
            if (bundle == null)
            {
                throw new ArgumentNullException("bundle");
            }

            bundle.Content = JavaScriptCompressor.Compress(bundle.Content);
            bundle.ContentType = "text/javascript";
        }
    }

    public class YuiCssMinify : IBundleTransform
    {
        /// <summary>
        /// Processes the specified bundle of CSS files.
        /// </summary>
        /// <param name="bundle">The CSS bundle.</param>
        public virtual void Process(BundleResponse bundle)
        {
            if (bundle == null)
            {
                throw new ArgumentNullException("bundle");
            }

            bundle.Content = CssCompressor.Compress(bundle.Content, 0, CssCompressionType.Hybrid, true);
            bundle.ContentType = "text/css";
        }

    }*/

    public class LessMinify : IBundleTransform
    {


        /// <summary>
        /// Processes the specified bundle of LESS files.
        /// </summary>
        /// <param name="bundle">The LESS bundle.</param>
        public void Process(BundleContext context, BundleResponse bundle)
        {
            if (bundle == null)
            {
                throw new ArgumentNullException("bundle");
            }

            context.HttpContext.Response.Cache.SetLastModifiedFromFileDependencies();

            var lessParser = new Parser();
            ILessEngine lessEngine = CreateLessEngine(lessParser);

            var content = new StringBuilder(bundle.Content.Length);

            foreach (FileInfo file in bundle.Files)
            {
                SetCurrentFilePath(lessParser, file.FullName);
                string source = File.ReadAllText(file.FullName);
                content.Append(lessEngine.TransformToCss(source, file.FullName));
                content.AppendLine();

                AddFileDependencies(lessParser);
            }

            bundle.Content = content.ToString();
            bundle.ContentType = "text/css";
            //base.Process(context, bundle);
        }

        /// <summary>
        /// Creates an instance of LESS engine.
        /// </summary>
        /// <param name="lessParser">The LESS parser.</param>
        private ILessEngine CreateLessEngine(Parser lessParser)
        {
            var logger = new AspNetTraceLogger(LogLevel.Debug, new Http());
            return new LessEngine(lessParser, logger, false, true);
        }

        /// <summary>
        /// Adds imported files to the collection of files on which the current response is dependent.
        /// </summary>
        /// <param name="lessParser">The LESS parser.</param>
        private void AddFileDependencies(Parser lessParser)
        {
            IPathResolver pathResolver = GetPathResolver(lessParser);

            foreach (string importedFilePath in lessParser.Importer.Imports)
            {
                string fullPath = pathResolver.GetFullPath(importedFilePath);
                HttpContext.Current.Response.AddFileDependency(fullPath);
            }

            lessParser.Importer.Imports.Clear();
        }

        /// <summary>
        /// Returns an <see cref="IPathResolver"/> instance used by the specified LESS lessParser.
        /// </summary>
        /// <param name="lessParser">The LESS prser.</param>
        private IPathResolver GetPathResolver(Parser lessParser)
        {
            var importer = lessParser.Importer as Importer;
            if (importer != null)
            {
                var fileReader = importer.FileReader as FileReader;
                if (fileReader != null)
                {
                    return fileReader.PathResolver;
                }
            }

            return null;
        }

        /// <summary>
        /// Informs the LESS parser about the path to the currently processed file. 
        /// This is done by using custom <see cref="IPathResolver"/> implementation.
        /// </summary>
        /// <param name="lessParser">The LESS parser.</param>
        /// <param name="currentFilePath">The path to the currently processed file.</param>
        private void SetCurrentFilePath(Parser lessParser, string currentFilePath)
        {
            var importer = lessParser.Importer as Importer;
            if (importer != null)
            {
                var fileReader = importer.FileReader as FileReader;

                if (fileReader == null)
                {
                    importer.FileReader = fileReader = new FileReader();
                }

                var pathResolver = fileReader.PathResolver as ImportedFilePathResolver;

                if (pathResolver != null)
                {
                    pathResolver.CurrentFilePath = currentFilePath;
                }
                else
                {
                    fileReader.PathResolver = new ImportedFilePathResolver(currentFilePath);
                }
            }
            else
            {
                throw new InvalidOperationException("Unexpected importer type on dotless parser");
            }


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