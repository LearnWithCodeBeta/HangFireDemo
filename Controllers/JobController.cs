using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangFireDemo.Models;
using HangFireDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, "Service is Working Fine!");
        }

        [HttpPost]
        public IActionResult CreateJob([FromBody] JobInfo jobInfo)
        {
            HangFireHelper service = new HangFireHelper();
            service.CreateJob(jobInfo);
            return StatusCode(200, null);
        }
    }
}