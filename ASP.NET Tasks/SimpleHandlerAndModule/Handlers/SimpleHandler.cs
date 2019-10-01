using System.Web;

namespace SimpleHandlerAndModule.Handlers
{
    public class SimpleHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>Custom Hander and Module</title>";
            fullHtmlCode += "<meta name=\"viewport\" content=\"width=device-width\" />";
            fullHtmlCode += "<style>";
            fullHtmlCode += ".column { float: left; width: 33%; }";
            fullHtmlCode += ".responsive { width: 100%; height:auto; }";
            fullHtmlCode += "</style>";
            fullHtmlCode += "</head><body>";
            fullHtmlCode += "<div class=\"row\">" +
                "<div class=\"column\"><img class=\"responsive\"  src=\"https://images.unsplash.com/photo-1475809913362-28a064062ccd?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80\"></div>" +
                "<div class=\"column\"><img class=\"responsive\" src=\"https://images.unsplash.com/photo-1437622368342-7a3d73a34c8f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=80\"></div>" +
                "<div class=\"column\"><img class=\"responsive\" src=\"https://images.unsplash.com/photo-1456926631375-92c8ce872def?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60\"></div>" +
                "</div>";
            fullHtmlCode += "</body></html>";

            context.Response.Write(fullHtmlCode);
        }
    }
}