using Castle.Windsor;

namespace Swampy.Domain
{
    public static class CastleConfiguration
    {


        public static void Configure()
        {

            var container = new WindsorContainer();
            container.Register(
                //Add Registration Here
                //Component.For<ITemplateReader>().ImplementedBy<TemplateReader>(), 
                );
        }
    }
}
