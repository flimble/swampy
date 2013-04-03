using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Swampy.Admin.Web.Infrastructure.HtmlExtensions;

namespace Swampy.Admin.Web.HtmlHelpers
{
    public static class TwitterHtmlExtensions
    {

        public static MvcHtmlString TwitterEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                     Expression<Func<TModel, TValue>> expression)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"control-group\">");
            sb.AppendLine(HtmlLabelExtensions.LabelFor(html, expression, new {@class = "control-label"}).ToString());
            sb.AppendLine("<div class=\"controls\">");
            sb.AppendLine(html.EditorFor(expression).ToString());
            sb.AppendLine(html.ValidationMessageFor(expression, null, new { @class="help-inline"}).ToString());
            sb.AppendLine(@"</div>");
            sb.AppendLine(@"</div>");

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString TwitterDisplayFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                   Expression<Func<TModel, TValue>> expression)
        {
            TValue modelData = expression.Compile().Invoke((TModel)html.ViewContext.ViewData.Model);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"control-group\">");
            sb.AppendLine(HtmlLabelExtensions.LabelFor(html, expression, new { @class = "control-label" }).ToString());
            sb.AppendLine("<div class=\"controls\">");         
            sb.AppendFormat("<span class=\"input-xlarge uneditable-input\">{0}</span>", modelData);
            sb.AppendLine(@"</div>");
            sb.AppendLine(@"</div>");

            return MvcHtmlString.Create(sb.ToString());
        }


        public static MvcHtmlString TwitterTextAreaEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                                   Expression<Func<TModel, TValue>> expression, int rows, int columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"control-group\">");
            sb.AppendLine(HtmlLabelExtensions.LabelFor(html, expression, new { @class = "control-label" }).ToString());
            sb.AppendLine("<div class=\"controls\">");
            sb.AppendLine(html.TextAreaFor(expression, rows, columns, null).ToString());
            sb.AppendLine(html.ValidationMessageFor(expression, null, new { @class = "help-inline" }).ToString());
            sb.AppendLine(@"</div>");
            sb.AppendLine(@"</div>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
