using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace _335a1.Controllers
{
    [Route("api")]
    [ApiController]
    public class GetVersionController : Controller
    {
        [HttpGet("GetVersion")]
        public string GetVersion()
        {
            string v1 = "V1";
            return v1;
        }

       
    }
}
