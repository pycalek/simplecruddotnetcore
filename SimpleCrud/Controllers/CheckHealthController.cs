using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SimpleCrud.Database;
using SimpleCrud.Models;


namespace SimpleCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckHealthController : ControllerBase
    {

        private readonly AppSettings _appSettings;

        public CheckHealthController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public IActionResult Get()
        {
            var result = "Application running on " + _appSettings.AppRegion + " Region";
            return Ok(result);
        }

    
    }
}