using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;


namespace AgileCourt.ScanListener.Controllers
{
    [RoutePrefix("api/values")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        //Download Installer
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage();
        }
    }
}
