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
using CQRS.Read.Infrastructure.Persistence;

namespace CQRS.ViewerMonitor
{
    public static class Initiator
    {
        public static IDataContext DataContext { get; set; }
        public static ICommandEventRepository CommandEventRepository { get; set; }

        private static OwinHttpListener owinHttpListener = null;

        public static void InitializeMonitor(IDataContext dataContext, ICommandEventRepository commandEventRepository, int port = 8080)
        {
            CommandEventRepository = commandEventRepository;
            DataContext = dataContext;

            WebApp.Start<Startup>($"http://localhost:{port}");
        }

        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var webApiConfiguration = ConfigureWebApi();
                app.UseWebApi(webApiConfiguration);
                app.UseNancy();
            }


            private HttpConfiguration ConfigureWebApi()
            {
                var config = new HttpConfiguration();

                config.MapHttpAttributeRoutes();

                config.Formatters.Clear();
                config.Formatters.Add(new JsonMediaTypeFormatter());
                config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

                return config;
            }
        }
    }
}
