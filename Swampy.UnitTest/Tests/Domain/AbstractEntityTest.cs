using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Swampy.Business.DomainModel.Entities;
using Swampy.Business.Infrastructure.Abstractions;

namespace Swampy.UnitTest.Tests.Domain
{
    [TestFixture]
    public class AbstractEntityTest
    {
        [Test]
        public void audit_information_set_on_create()
        {
            var expectedDate = new DateTime(2012, 11, 19, 0, 0, 0);
            SystemTime.Now = () => expectedDate;

            var underTest = new MockEntity();

            Assert.AreEqual("John Doe", underTest.ModificationDetails.UserName);
            Assert.AreEqual(expectedDate, underTest.ModificationDetails.TimeStamp);
        }


        private class MockEntity : AbstractEntity
        {
            
        }
    }


}
