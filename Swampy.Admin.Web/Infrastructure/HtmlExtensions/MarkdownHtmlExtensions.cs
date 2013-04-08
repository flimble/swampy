using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using MarkdownSharp;

namespace Swampy.Admin.Web.Infrastructure.HtmlExtensions
{
    public static class MarkdownHtmlExtensions
    {
             public static MvcHtmlString MarkDown(this HtmlHelper helper, string markdownText)
             {
                 Markdown markdown = new Markdown();
                 string transformed = markdown.Transform(markdownText);

                 return new MvcHtmlString(transformed);
             }
    }
}