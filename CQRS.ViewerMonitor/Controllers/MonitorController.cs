using CQRS.Write.Domain;
using CQRS.Write.Domain.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CQRS.ViewerMonitor.Controllers
{
    public class MonitorController : ApiController
    {
        // GET api/demo 
        public IEnumerable<object> Get()
        {
            return Initiator.DataContext.Cars.Get();
        }

        // GET api/demo/5 
        public IEnumerable<object> Get(int id)
        {
            return Initiator.CommandEventRepository.GetEvents(id);
        }

        // POST api/demo 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/demo/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/demo/5 
        public void Delete(int id)
        {
        }
    }
}
