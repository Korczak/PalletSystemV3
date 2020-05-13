using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using PalletSystem.Core.Users;
using PalletSystem.Core.Users.Register;

namespace PalletSystem.Web.Users
{
    public class UsersController : ControllerBase
    {
        private readonly UserRegisterService _userRegisterService;

        public UsersController(UserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

        [HttpPost("api/users")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserRegisterResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(UserRegisterResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            var user = User.GetBasicUserData();
            var result = await _userRegisterService.RegisterUser(request, user);

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
