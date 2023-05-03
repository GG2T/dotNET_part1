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
    public class productController : Controller
    {
        private readonly IWebAPIRepo _repository;

        public productController(IWebAPIRepo repository)
        {
            _repository = repository;
        }



        [HttpGet("GetItems")]

        public ActionResult<ProductOutDto> GetItems()
        {


            IEnumerable<Product> products = _repository.GetItems();
            IEnumerable<ProductOutDto> A = products.Select(a => new ProductOutDto { Id = a.Id, Name = a.Name, Description = a.Description, Price = a.Price });
            return Ok(A);








        }

        [HttpGet("GetItems/{name}")]

        public ActionResult<ProductOutDto> GetItems(string name)
        {


            IEnumerable<Product> Productsz = _repository.GetItems(name).ToList();
            if (Productsz == null)
            {
                return NotFound();
            }
            else
            {
                IEnumerable<ProductOutDto> p = Productsz.Select(name => new ProductOutDto { Id = name.Id, Name = name.Name, Description = name.Description, Price = name.Price });
                return Ok(p);
            }



            //IEnumerable<ProductOutDto> A = Products.Select(a => new ProductOutDto { Id = a.Id, Name = a.Name, Description = a.Description, Price = a.Price });



        }

        [HttpGet("GetItemPhoto/{id}")]

        public ActionResult GetItemPhoto(int id)
        {


            string itemloc = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "ItemsImages"), id + ".jpg");
            string itemloc1 = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "ItemsImages"), id + ".png");

            Product Products = _repository.GetItemByID(id);
            string file = "";
            string type= "";
            if (Products != null)
            {

                if (System.IO.File.Exists(itemloc))
                {
                    file = itemloc;
                    type = "image/jpeg";
                }
                if (System.IO.File.Exists(itemloc1))
                {
                    file = itemloc1;
                    type = "image/png";
                }
            }
            else 
            {
                return PhysicalFile(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "ItemsImages"), "default.png"), "image/png");
            }

            return PhysicalFile(file, type); 
        }
    }
}

