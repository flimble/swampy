using NUnit.Framework;
using Swampy.UnitTest.Helpers;

namespace Swampy.UnitTest
{
    [TestFixture]
    public class RoundhouseSchemUpdateScriptGenerator
    {
        
        [Test]
        [Explicit]
        public void generate_roundhouse_scripts_based_on_changes()
        {
            var db = new NHibernateSchemaUpdateDatabase();
            db.BuildSchema();

        }


    }
}
