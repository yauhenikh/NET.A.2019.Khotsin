using SimpleHandlerAndModule.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleHandlerAndModule
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route("handler/{*path}", new CustomRouteHandler()));
        }

        class CustomRouteHandler : IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return new SimpleHandler();
            }
        }
    }
}
