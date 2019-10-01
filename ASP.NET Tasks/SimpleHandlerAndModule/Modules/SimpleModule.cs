using SimpleHandlerAndModule.Handlers;
using System.Web;

namespace SimpleHandlerAndModule.Modules
{
    public class SimpleModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += (src, args) =>
            {
                context.Context.RemapHandler(new SimpleHandler());
            };
        }
    }
}