using Microsoft.Owin.Hosting;
using Microsoft.Owin.Host.HttpListener;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using CQRS.Write.Domain.Commands;

namespace CQRS.ViewerMonitor
{
    public static class Initiator
    {
        public static ICommandEventRepository CommandEventRepository { get; set; }

        private static OwinHttpListener owinHttpListener = null;

        public static void InitializeMonitor(ICommandEventRepository commandEventRepository, int port = 8080)
        {
            CommandEventRepository = commandEventRepository;

            WebApp.Start<Startup>($"http://localhost:{port}");
        }

        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var webApiConfiguration = ConfigureWebApi();
                app.UseWebApi(webApiConfiguration);
            }


            private HttpConfiguration ConfigureWebApi()
            {
                var config = new HttpConfiguration();

                config.Routes.MapHttpRoute(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional });

                config.Formatters.Clear();
                config.Formatters.Add(new JsonMediaTypeFormatter());
                config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

                return config;
            }
        }
    }
}
