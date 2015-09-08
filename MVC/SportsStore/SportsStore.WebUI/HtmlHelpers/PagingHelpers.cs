using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder resultHtml = new StringBuilder();
            StringBuilder liHtml = new StringBuilder();
            double tempTotalPages = pagingInfo.TotalItems / pagingInfo.ItemsPerPage;
            double totalPages = Math.Floor(tempTotalPages);

            //Final HTML markup 
            //<ul class="pagination">
            //  <li><a href="Page1">1</a>
            //  <li><a href="Page2">2</a>
            //</ul>

            //Create <ul></ul> tag
            TagBuilder ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");

            for (int i = 1; i <= totalPages+1; i++)
            {
                StringBuilder aHtml = new StringBuilder();

                //Create <a></a> tag
                TagBuilder aTag = new TagBuilder("a");
                aTag.MergeAttribute("href",pageUrl(i));
                aTag.InnerHtml = i.ToString();

                //create li tag and add <a> tag into it
                TagBuilder liTag = new TagBuilder("li");
                liTag.InnerHtml = aTag.ToString();

                if (i == pagingInfo.CurrentPage)
                {
                    liTag.AddCssClass("active");
                }

                liHtml.Append(liTag.ToString());
            }
            ulTag.InnerHtml = liHtml.ToString();

            return MvcHtmlString.Create(ulTag.ToString());
        }
    }
}