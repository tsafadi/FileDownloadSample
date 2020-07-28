using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileDownloadSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        public DownloadController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        [HttpGet("DownloadFile")]
        public IActionResult DownloadFile()
        {
            // Since this is just and example, I am using a local file located inside wwwroot
            // Afterwards file is converted into a stream
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "Sample.xlsx");
            var fs = new FileStream(path, FileMode.Open);

            // Return the file. A byte array can also be used instead of a stream
            return File(fs, "application/octet-stream", "Sample.xlsx");
        }
    }
}
