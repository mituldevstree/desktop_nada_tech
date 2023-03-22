using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace NadaTech_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        protected void Application_BeginRequest()
        {

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                //These headers are handling the "pre-flight" OPTIONS call sent by the browser
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST,DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Accepts, Content-Type, Origin, X-My-Header");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "60");
                HttpContext.Current.Response.End();


            }
        }
    }
}
