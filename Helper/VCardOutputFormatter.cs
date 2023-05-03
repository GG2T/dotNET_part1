using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using _335a1.Dtos;
using _335a1.Models;

namespace _335a1.Helper
{
    public class VCardOutputFormatter : TextOutputFormatter
    {
        public VCardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            CardOutputDto cardOut = (CardOutputDto)context.Object;
            StringBuilder builder = new StringBuilder();

            Staff staff = new Staff();
            builder.AppendLine("BEGIN:VCARD");
            builder.AppendLine("VERSION:4.0");
            builder.Append("N:").AppendLine(cardOut.LastName + ";" + cardOut.FirstName + ";;" + cardOut.Title + ";");
            builder.Append("FN:").AppendLine(cardOut.Title + " " + cardOut.FirstName + " " + cardOut.LastName);

            if (cardOut.Id != -2)
            {
                
                builder.Append("UID:").AppendLine(cardOut.Id + "");

            }
            else {
                string id = "";
                builder.Append("UID:").AppendLine(id);
            }
            
            
            builder.Append("ORG:").AppendLine("Southern Hemisphere Institue of Technology");
            builder.Append("Email;").Append("TYPE=work:").AppendLine(cardOut.Email);
            builder.Append("TEL:").AppendLine(cardOut.Tel);
            builder.Append("URL:").AppendLine(cardOut.Url);
            builder.Append("CATEGORIES:").AppendLine(cardOut.Research);
            builder.Append("PHOTO;ENCODING=BASE64;TYPE=JPEG").Append(cardOut.PhotoType).Append(":").AppendLine(cardOut.Photo);
            builder.Append("LOGO;ENCODING=BASE64;TYPE=").Append(cardOut.LogoType).Append(":").AppendLine(cardOut.Logo);

            builder.AppendLine("END:VCARD");
            string outString = builder.ToString();
            byte[] outBytes = selectedEncoding.GetBytes(outString);
            var response = context.HttpContext.Response.Body;
            return response.WriteAsync(outBytes, 0, outBytes.Length);
        }
    }
}
