using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using MvcContrib.TestHelper.Fakes;
using NUnit.Framework;
using Rhino.Mocks;
using Swampy.Admin.Web.Controllers;
using Swampy.Admin.Web.HtmlHelpers;

namespace Swampy.UnitTest.Tests.Admin.MVC.HtmlHelpers
{
    [TestFixture]
    public class TwitterHtmlExtensionsTest
    {
        public static HtmlHelper<TModel> CreateHtmlHelper<TModel>(ViewDataDictionary vd)
        {
            var httpContext = MockRepository.GenerateStub<HttpContextBase>();                      
            httpContext.Stub(x => x.Items).Return(new Dictionary<object, object>());

            var viewEngineResult = new ViewEngineResult(new List<string>());
            ViewEngines.Engines.Clear();
            var mockViewEngine = MockRepository.GenerateStub<IViewEngine>();
            mockViewEngine.Stub(x => x.FindPartialView(null, "", false))
                          .IgnoreArguments()
                          .Return(viewEngineResult);

            mockViewEngine.Stub(x => x.FindView(null, "", "", false))
                          .IgnoreArguments()
                          .Return(viewEngineResult);
            
            ViewEngines.Engines.Add(mockViewEngine);

            var routeData = new RouteData();
            routeData.Values["controller"] = "home";
            routeData.Values["action"] = "index";


            var controllerContext = new ControllerContext(
                httpContext,
                routeData,
                MockRepository.GenerateStub<AbstractController>());

            
            

            var mockViewContext = new ViewContext(
                controllerContext,
              MockRepository.GenerateStub<IView>(),
              vd,
              new TempDataDictionary(),
              TextWriter.Null);
            mockViewContext.ClientValidationEnabled = true;
            mockViewContext.UnobtrusiveJavaScriptEnabled = true;

            var mockViewDataContainer = MockRepository.GenerateStub<IViewDataContainer>();
            mockViewDataContainer.ViewData = vd;


            return new HtmlHelper<TModel>(mockViewContext, mockViewDataContainer);

        }

      
        
        [Test]
        [TestCase("sf", "aProperty", "bla")]
        public void twittereditorfor_with_error_outputs_error_class(string propertyText, string errorProperty, string errorMessage)
        {
            var viewData = new ViewDataDictionary<FakeModel>(new FakeModel { aProperty = propertyText });
            
            viewData.ModelState.AddModelError(errorProperty, errorMessage);
            var helper = CreateHtmlHelper<FakeModel>(viewData);

            var result = helper.BootstrapEditorFor(model => model.aProperty);


            string expected =
                string.Format(
                    "<div class=\"control-group\">"+
                    "<label class=\"control-label\" for=\"aProperty\">{0}</label><div class=\"controls\">"+
                    "<input class=\"input-validation-error text-box single-line\" id=\"aProperty\" name=\"aProperty\" type=\"text\" value=\"{1}\" />"+
                    "<span class=\"field-validation-error help-inline\" data-valmsg-for=\"aProperty\" data-valmsg-replace=\"true\">{2}</span>"+
                    "</div></div>", errorProperty, propertyText, errorMessage);

            Assert.IsTrue(expected.Equals(result.ToString().Replace(Environment.NewLine, "")));

        }


        [Test]
        [TestCase("sf")]
        public void twittereditorfor_without_error_outputs_label_and_editor(string propertyText)
        {
            var viewData = new ViewDataDictionary<FakeModel>(new FakeModel { aProperty = propertyText });

            
            var helper = CreateHtmlHelper<FakeModel>(viewData);

            var result = helper.BootstrapEditorFor(model => model.aProperty);


            string expected =
                string.Format(
                    "<div class=\"control-group\">"+
                    "<label class=\"control-label\" for=\"aProperty\">aProperty</label>"+
                    "<div class=\"controls\">"+
                    "<input class=\"text-box single-line\" id=\"aProperty\" name=\"aProperty\" type=\"text\" value=\"{0}\" />"+
                    "<span class=\"field-validation-valid help-inline\" data-valmsg-for=\"aProperty\" data-valmsg-replace=\"true\">"+
                    "</span></div></div>",propertyText);

            Assert.IsTrue(expected.Equals(result.ToString().Replace(Environment.NewLine, "")));

        }

          [Test]
        [TestCase("sf", 4, 1)]
        public void twittereditorfor_without_error_outputs_label_and_editor(string propertyText, int rows, int columns)
        {
            var viewData = new ViewDataDictionary<FakeModel>(new FakeModel { aProperty = propertyText });

            
            var helper = CreateHtmlHelper<FakeModel>(viewData);

            var result = helper.BootstrapTextAreaEditorFor(model => model.aProperty, rows, columns);


            string expected =
                string.Format(
                    "<div class=\"control-group\">" + 
                    "<label class=\"control-label\" for=\"aProperty\">aProperty</label>" + 
                    "<div class=\"controls\">" + 
                    "<textarea cols=\"{0}\" id=\"aProperty\" name=\"aProperty\" rows=\"{1}\">{2}</textarea>" +
                    "<span class=\"field-validation-valid help-inline\" data-valmsg-for=\"aProperty\" data-valmsg-replace=\"true\">"+
                    "</span></div></div>", columns, rows, propertyText);

            Assert.IsTrue(expected.Equals(result.ToString().Replace(Environment.NewLine, "")));

        }


        class FakeModel
        {
            public string aProperty { get; set; }
        }
    }


}
