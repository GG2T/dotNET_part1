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
    

    public class GetlogoController : Controller
    {
        [HttpGet("GetLogo")]
        public ActionResult GetLogo()
        {


            

           

            string logoloca = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "StaffPhotos"), "logo.png");

            return PhysicalFile(logoloca,"image/png");
        }
    }
}
