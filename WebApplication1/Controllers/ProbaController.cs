using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProbaController : ControllerBase
    {


        // POST api/<ProbaController>
        [HttpPost]
        public void Post([FromForm] ImageDto dto)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);
            var newImageName = guid + extension;
            var path = Path.Combine("wwwroot", "images", newImageName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }
        }

        
    }

    public class ImageDto
    {
        public IFormFile Image { get; set; }
    }
}
