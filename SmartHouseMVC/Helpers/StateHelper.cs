using System.Web.Mvc;

namespace SmartHouseMVC.Helpers
{
    public static class StateHelper
    {
        public static MvcHtmlString CreateState(this HtmlHelper html, bool state, string cssClass)
        {
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass(cssClass);
            if (state == true)
            {
                span.InnerHtml = "Включен";
            }
            else
            {
                span.InnerHtml = "Выключен";
            }
            return new MvcHtmlString(span.ToString());
        }
    }
}