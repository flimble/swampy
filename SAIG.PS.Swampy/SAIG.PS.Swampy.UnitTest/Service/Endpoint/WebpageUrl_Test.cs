﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAIG.PS.Swampy.Service.Entities.Endpoint;

namespace SAIG.PS.Swampy.UnitTest.Endpoint
{
    [TestFixture]
    public class WebpageUrl_Test
    {
        [Test]
        public void url_correctly_validates()
        {
            var underTest = new WebpageUrl();
            Assert.IsFalse(underTest.IsValid("http://admin.sit1.property. saiglobal.com"));
            Assert.IsTrue(underTest.IsValid("http://admin.sit1.property.saiglobal.com"));
        }
    }
}