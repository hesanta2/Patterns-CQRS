using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.ViewerMonitor.Controllers
{
    public class MonitorController : NancyModule
    {
        public MonitorController()
        {
            Get["Monitor"] = _ => View["Views/Index"];
            //Get["/"] = Index;
        }

        private dynamic Index(dynamic parameters)
        {
            //var input = this.Bind<1>();
            return View["Index", 1];
        }

    }
}
