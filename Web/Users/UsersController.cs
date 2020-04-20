using Core.Users;
using Core.Users.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Web.Users
{
    public class UsersController : ControllerBase
    {
        private readonly UserRegisterService _userRegisterService;

        public UsersController(UserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

        [HttpPost("api/users")]
        [ProducesResponseType(typeof(UserRegisterResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(UserRegisterResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest input)
        {
            var user = User.GetBasicUserData();
            var result = await _userRegisterService.RegisterUser(input, user);

            if (result.Status == UserRegisterStatus.Success)
            {
                return Created($"api/users/{result.Username}", result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
