using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Application.TransferObject.Request.Module;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSecurity.UI.WebApi.Controllers
{
    [Route("api/Module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }
        [HttpGet("ListModule")]
        public IActionResult ListModule()
        {
            var result = _moduleService.ListModule();
            return Ok(result);
        }
        [HttpGet("GetModule/{id}")]
        public IActionResult GetModule(int id)
        {
            var result = _moduleService.GetModule(id);
            return Ok(result);
        }
        [HttpPost("CreateModule")]
        public IActionResult CreateModule(ModuleRequest moduleRequest)
        {
            var result = _moduleService.CreateModule(moduleRequest);
            return Ok(result);
        }
        [HttpPut("UpdateModule")]
        public IActionResult UpdateModule(ModuleRequest moduleRequest)
        {
            var result = _moduleService.UpdateModule(moduleRequest);
            return Ok(result);
        }
        [HttpDelete("DeleteModule/{id}")]
        public IActionResult DeleteModule(int id)
        {
            var result = _moduleService.DeleteModule(id, 1);
            return Ok(result);
        }
    }
}
