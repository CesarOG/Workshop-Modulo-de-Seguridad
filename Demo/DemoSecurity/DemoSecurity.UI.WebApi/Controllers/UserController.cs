using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Application.TransferObject.Request.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSecurity.UI.WebApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("ListUser")]
        public IActionResult ListUser()
        {
            var result = _userService.ListUser();
            return Ok(result);
        }
        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            var result = _userService.GetUser(id);
            return Ok(result);
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserRequest userRequest)
        {
            var result = _userService.CreateUser(userRequest);
            return Ok(result);
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(UserRequest userRequest)
        {
            var result = _userService.UpdateUser(userRequest);
            return Ok(result);
        }
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id, 1);
            return Ok(result);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest login)
        {
            var result = _userService.Login(login);
            return Ok(result);
        }
    }
}
