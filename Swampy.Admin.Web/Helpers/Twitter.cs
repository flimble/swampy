using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Swampy.Admin.Web.HtmlHelpers
{
    public static class TwitterHtmlExtensions
    {
        /*public static MvcHtmlString TwitterEditorFor(this HtmlHelper html)
        {
            return MvcHtmlString.Create("Hello world");
        }*/

        public static MvcHtmlString TwitterEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                     Expression<Func<TModel, TValue>> expression)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"control-group\">");
            sb.AppendLine(html.LabelFor(expression).ToString());
            sb.AppendLine("<div class=\"controls\">");
            sb.AppendLine(html.EditorFor(expression).ToString());
            sb.AppendLine(html.ValidationMessageFor(expression).ToString());
            sb.AppendLine(@"<\div>");
            sb.AppendLine(@"<\div>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
