using GrantManagementApi.BusinessModel;
using GrantManagementApi.DtoRequest;
using GrantManagementApi.Models;
using GrantManagementApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagementApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        public UsersController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        [HttpGet("getusers")]
        public IActionResult Get()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];
            var test = AuthorizationModel.DecodeJWT(accessToken);
            var users = new List<string>
            {
                "Satinder Singh",
                "Amit Sarna",
                "Davin Jon"
            };

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserRequest usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);
            token.Success = true;
            token.Message = "User Authenticated";

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
