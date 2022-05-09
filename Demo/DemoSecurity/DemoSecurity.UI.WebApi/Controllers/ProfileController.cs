using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Application.TransferObject.Request.Profile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSecurity.UI.WebApi.Controllers
{
    [Route("api/Profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet("ListProfile")]
        public IActionResult ListProfile()
        {
            var result = _profileService.ListProfile();
            return Ok(result);
        }
        [HttpGet("GetProfile/{id}")]
        public IActionResult GetProfile(int id)
        {
            var result = _profileService.GetProfile(id);
            return Ok(result);
        }
        [HttpPost("CreateProfile")]
        public IActionResult CreateProfile(ProfileRequest profileRequest)
        {
            var result = _profileService.CreateProfile(profileRequest);
            return Ok(result);
        }
        [HttpPut("UpdateProfile")]
        public IActionResult UpdateProfile(ProfileRequest profileRequest)
        {
            var result = _profileService.UpdateProfile(profileRequest);
            return Ok(result);
        }
        [HttpDelete("DeleteProfile/{id}")]
        public IActionResult DeleteProfile(int id)
        {
            var result = _profileService.DeleteProfile(id, 1);
            return Ok(result);
        }
    }
}
