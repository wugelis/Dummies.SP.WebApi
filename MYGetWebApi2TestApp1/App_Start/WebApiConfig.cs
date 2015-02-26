using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MYGetWebApi2TestApp1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{fileName}/{nameSpaceName}/{className}/{methodName}/{*pathInfo}",
                defaults: new
                {
                    controller = "DummiesApiHost",
                    id = RouteParameter.Optional
                }
            );
        }
    }
}
