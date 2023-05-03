using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using _335a1.Models;
using _335a1.Data;
using _335a1.Dtos;

namespace _335a1.Controllers
{
    [Route("api")]
    [ApiController]
    public class GetAllStaffController : Controller
    {
        private readonly IWebAPIRepo _repository;

        public GetAllStaffController(IWebAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllStaff")]

        public ActionResult<IEnumerable<StaffOutputDto>> GetAllStaffs()
        {
            IEnumerable<Staff> Staffs = _repository.GetStaffs();
            IEnumerable<StaffOutputDto> S = Staffs.Select(a => new StaffOutputDto { Id = a.Id, FirstName = a.FirstName, LastName = a.LastName,Title = a.Title,Email = a.Email,Tel = a.Tel,Url = a.Url,Research = a.Research });
            return Ok(S);
        }
        
        
        [HttpGet("GetStaffPhoto/{id}")]
        public ActionResult GetStaffPhoto(string id)
        {
            string photoloca = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "StaffPhotos"), id + ".jpg");
            
            if (System.IO.File.Exists(photoloca))
            {
                return PhysicalFile(photoloca, "image/jpeg");
            }
            else
            {
                return PhysicalFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "StaffPhotos"), "default.png"),"image/png");
            }
                
            

            

        }
    }

}

   

