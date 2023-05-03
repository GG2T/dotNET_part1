using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _335a1.Data;
using _335a1.Models;
using _335a1.Dtos;
using System.IO;
using System.Drawing;
using _335a1.Helper;
using System.Drawing.Imaging;
using WebAPIvCard.Helper;

namespace _335a1.Controllers
{
    [Route("api")]
    [ApiController]
    public class GetVCardController : Controller
    {
        private readonly IWebAPIRepo _cardRepo;



        public GetVCardController(IWebAPIRepo cardRepo)
        {
            _cardRepo = cardRepo;
        }
      [HttpGet("GetCard/{id}")]

      public  ActionResult GetCard(int id)
        {
            Staff staffs = _cardRepo.GetCard(id);
            string location = Directory.GetCurrentDirectory();
            string sp = Path.Combine(location, "StaffPhotos/" + id + ".jpg");
            


            CardOutputDto cardOut = new CardOutputDto();

            string photoString, photoType,logoString,logoType;
            ImageFormat imageFormat,imageFormat1;
            if (staffs != null)
            {
                
                
                Image image = Image.FromFile(sp);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(100, 100), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
                cardOut.FirstName = staffs.FirstName;
                cardOut.LastName = staffs.LastName;
                cardOut.Id = staffs.Id;
                cardOut.Title = staffs.Title;
                cardOut.Tel = staffs.Tel;
                cardOut.Url = staffs.Url;
                cardOut.Email = staffs.Email;
                cardOut.Research = staffs.Research;
                cardOut.PhotoType = photoType;
                cardOut.Photo = photoString;
                string logo = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "StaffPhotos"), "logo.png");
                Image Logo = Image.FromFile(logo);
                imageFormat1 = Logo.RawFormat;
                Logo = ImageHelper.Resize(Logo, new Size(100, 100), out logoType);
                logoString = ImageHelper.ImageToString(Logo, imageFormat1);
                cardOut.LogoType = logoType;
                cardOut.Logo = logoString;
                

                Response.Headers.Add("Content-Type", "text/vcard");
                return Ok(cardOut);
            }
            else
            {
                cardOut.Id = -2;

                string logo = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "StaffPhotos"), "default.png");
                Image Logo = Image.FromFile(logo);
                imageFormat1 = Logo.RawFormat;
                Logo = ImageHelper.Resize(Logo, new Size(100, 100), out logoType);
                logoString = ImageHelper.ImageToString(Logo, imageFormat1);
                cardOut.LogoType = logoType;
                cardOut.Logo = logoString;
                cardOut.FirstName = "";
                

                cardOut.Title = "";
                cardOut.Tel = "";
                cardOut.Url = "";
                cardOut.Email = "";
                cardOut.Research = "";

                Response.Headers.Add("Content-Type", "text/vcard");
                return Ok(cardOut);


            }
            




        }
        
    }
}
