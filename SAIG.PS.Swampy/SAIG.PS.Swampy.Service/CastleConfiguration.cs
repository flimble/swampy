using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using log4net;

namespace SAIG.PS.Swampy.Service
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
