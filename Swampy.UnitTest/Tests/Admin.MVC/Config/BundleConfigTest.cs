using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;
using MvcContrib.TestHelper.Fakes;
using NUnit.Framework;
using Swampy.Admin.Web.App_Start;

namespace Swampy.UnitTest.Tests.Admin.MVC.Config
{
    [TestFixture]
    public class BundleConfigTest
    {
        private readonly BundleContext _mockBundleContext;

        public BundleConfigTest()
        {
            _mockBundleContext = new BundleContext(new FakeHttpContext(string.Empty), new BundleCollection(), string.Empty);
        }

        [SetUp]
        public void Setup()
        {
            var bundles = BundleTable.Bundles;
            bundles.Clear();

            BundleTable.MapPathMethod = MapBundleItemPath;
            BundleConfig.RegisterBundles(bundles);


        }

        private static string MapBundleItemPath(string item)
        {
            //TODO: Replace this with whatever logic you need to map from your virtual paths to a physical path

            // Strip the ~ and switch from / to \
            item = item.Replace("~", string.Empty).Replace("/", @"\");

            // Join the item virtual path with the location of your MVC project
            var executingDir = new Uri(Directory.GetCurrentDirectory());
            var rootDir = new Uri(executingDir, @"../../");
            var pathToMvcProject = Path.Combine(rootDir.LocalPath,
                                            @"Swampy.Admin.Web");

            return string.Format("{0}{1}", pathToMvcProject, item);
        }

        [Test]
        public void jquery_bundle_contains_jquery()
        {            
            var jqueryBundle = GetFilesInBundle(@"~/bundles/jquery");            
            Assert.IsTrue(jqueryBundle.Contains("jquery-1.8.2.js"));
        }

        [Test]
        public void nonspecified_bundle_not_created()
        {
            Assert.IsFalse(BundleTable.Bundles.Any(x=>x.Path=="zForZachariah"));
        }

        /// <summary>
        /// Builds the list of file names in the specified bundle
        /// Names are lower cased in ascending order
        /// </summary>
        private List<string> GetFilesInBundle(string bundleName)
        {
            var bundle = BundleTable.Bundles.First(x => x.Path == bundleName);
            return bundle.EnumerateFiles(_mockBundleContext)
                .Select(x => x.Name.ToLower())
                .OrderBy(x => x)
                .ToList();
        }
    }
}
