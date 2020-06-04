using SportsStore.Webapp.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace SportsStore.Webapp.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo,
            Func<int, string> pageUrl)
        {
            StringBuilder resSb = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tagTb = new TagBuilder("a");
                tagTb.MergeAttribute("href", pageUrl(i));
                tagTb.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrPage)
                {
                    tagTb.AddCssClass("selected");
                    tagTb.AddCssClass("btn-primary");
                }

                tagTb.AddCssClass("btn btn-default");
                resSb.Append(tagTb.ToString());
            }

            return MvcHtmlString.Create(resSb.ToString());
        }
    }
}