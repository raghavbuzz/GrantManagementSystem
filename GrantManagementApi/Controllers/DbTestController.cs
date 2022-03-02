using GrantManagementApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            GrantManagementContext context = HttpContext.RequestServices.GetService(typeof(GrantManagementContext)) as GrantManagementContext;
            var result = context.GetAllDbTest();
            return Ok(result);
        }
    }
}
