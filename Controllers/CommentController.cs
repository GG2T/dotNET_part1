using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using _335a1.Models;
using _335a1.Data;
using _335a1.Dtos;
using System.Net;

namespace _335a1.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IWebAPIRepo _repository;

        public CommentController(IWebAPIRepo repository)
        {
            _repository = repository;
        }


        [HttpPost("WriteComment")]

        public ActionResult WriteComment(CommentInDto Comment)
        {
            //similar to AddCustomer
            Comment c = new Comment
            {
                Time = DateTime.Now,
                Comments = Comment.Comment,
                Name = Comment.Name,
                Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString()
            };
            Comment write = _repository.WriteComment(c);
            CommentOutDto cout = new CommentOutDto { Id = write.Id, Time = DateTime.Now, Comment = write.Comments, Name = write.Name, Ip = write.Ip };
            _repository.SaveChanges();
            return CreatedAtAction(nameof(GetComments), new { Id = cout.Id }, cout);
        }

       


        [HttpGet("GetComments")]

        public ActionResult GetComments()
        {

            IEnumerable<Comment> getc = _repository.GetComments();
            
            string html = "<html><head><title></title></head><body>";

            int count = 0;

            
            foreach (Comment cc in getc)
            {
                if (count < 5)
                {
                    html += "<p> ";
                    html += cc.Comments;
                    html += " &mdash; ";
                    html += cc.Name;
                    html += "</p>";
                }
                else
                {
                    break;


                }
                count += 1;
            }
            ContentResult c = new ContentResult
            {
                Content = html,
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
            };
            return c;
        }


    }  
}


