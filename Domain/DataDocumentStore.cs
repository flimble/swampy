using System;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace Swampy.Domain
{

    /// <summary>
    /// Basic Session/Datacontext style class for access to the Mongo Database.
    /// Not strictly a Session as there is no support for transactional chaining
    /// </summary>
    public class DataDocumentStore
    {
        private static IDocumentStore instance;

        public static IDocumentStore Instance
        {
            get
            {
                if(instance==null)
                {
                    throw new InvalidOperationException("IDocumentStore has not been inistialized");
                    
                }
                return instance;
            }
        }

        public static void Initialize()
        {
            
            instance = new DocumentStore { Url = "http://localhost:8080" } ;
            instance.Conventions.IdentityPartsSeparator = "-";
            instance.Initialize();
        }

        internal static void InitializeForTest()
        {
            instance = new EmbeddableDocumentStore { 
                Configuration = {
                    RunInMemory = true,
                    RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true
                },
            };
            instance.Conventions.IdentityPartsSeparator = "-";
            instance.Initialize();
        }
        

    }

}
