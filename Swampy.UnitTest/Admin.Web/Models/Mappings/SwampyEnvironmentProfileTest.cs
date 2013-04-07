using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NUnit.Framework;
using Swampy.Admin.Web.Models;
using Swampy.Admin.Web.Models.Mappers;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Tests.Admin.Web.Models.Mappings
{
    [TestFixture]
    public class SwampyEnvironmentProfileTest
    {
        [SetUp]
        public void Setup()
        {

            Mapper.Initialize(x =>
                {
                    x.AddProfile<ConfigurationItemProfile>();//Required for nested mapping   
                    x.AddProfile<SwampyEnvironmentProfile>();
                }); 
             
        }

        [Test]
        [TestCase("name", "domain")]
        public void input_maps_all_required_fields_to_entitiy(string name, string domain)
        {
            var inputModel = new EnvironmentInputModel
                {
                    Domain = domain,
                    Name = name
                };
            
            inputModel.ConfigurationItems.Add(new ConfigurationItemInputModel());


            var entity = Mapper.Map<EnvironmentInputModel, SwampyEnvironment>(inputModel);

            Assert.AreEqual(name, entity.Name);
            Assert.AreEqual(domain, entity.Domain);
            Assert.AreEqual(1, inputModel.ConfigurationItems.Count);
        }
    }
}
