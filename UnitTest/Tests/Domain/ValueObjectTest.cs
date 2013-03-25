using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Swampy.Business.DomainModel.ValueObjects;

namespace Swampy.UnitTest.Domain
{
    [TestFixture]
    public class ValueObjectTest
    {
        [Test]
        public void Two_valueobjects_with_same_registered_properties_are_equal()
        {
            var a = new MockValueObject("one", "two");
            var b = new MockValueObject("one", "two");

            Assert.AreEqual(a,b);
        }

        [Test]
        public void Two_valueobjects_with_same_registered_properties_are_not_equal()
        {
            var a = new MockValueObject("one", "two");
            var b = new MockValueObject("four", "five");

            Assert.AreNotEqual(a, b);
        }


        public class MockValueObject : ValueObjectBase<MockValueObject>
        {
            public string FirstProperty { get; set; }
            public string SecondProperty { get; set; }

            public MockValueObject(string firstProperty, string secondProperty)
            {
                this.FirstProperty = firstProperty;
                this.SecondProperty = secondProperty;


                RegisterProperty(x=>x.FirstProperty);
                RegisterProperty(x=>x.SecondProperty);
            }
        }
    }
}
