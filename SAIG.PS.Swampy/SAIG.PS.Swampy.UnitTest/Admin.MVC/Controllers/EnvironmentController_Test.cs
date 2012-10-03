using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using SAIG.PS.Swampy.Admin.MVC.Controllers;
using SAIG.PS.Swampy.MongoDataAccess;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;

namespace SAIG.PS.Swampy.UnitTest.Admin.MVC.Controllers
{
    [TestFixture]
    public class EnvironmentController_Test
    {
        [Test]
        public void Index()
        {
            //arrange
            var session = MockRepository.GenerateStub<ISession>();
            session.Stub(s => s.Query(MockRepository.GenerateStub<IQueryObject<Environment>>()))
                .IgnoreArguments()
                .Return(

                new List<Environment>
                    {                        
                     new Environment
                     {
                         Name = "Bla"
                     }
                        
                    }.AsQueryable()
                );


            var controller = new EnvironmentController(session);

            //act
            var result = controller.Index("SIT1");

            //assert
            result.AssertViewRendered();
        }
    }
}
