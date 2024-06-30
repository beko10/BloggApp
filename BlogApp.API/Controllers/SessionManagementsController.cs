using BlogApp.API.Extensions;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionManagementsController : ControllerBase
    {
        private readonly ISessionManagementService _sessionManagementService;

        public SessionManagementsController(ISessionManagementService sessionManagementService)
        {
            _sessionManagementService = sessionManagementService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _sessionManagementService.RegisterUserAsync(registerDto);
            if (result.Succeeded)
            {
                return Ok(registerDto);
            }
            ModelState.AddModelStateErrorList(result.Errors);
            return BadRequest(ModelState);
        }

        [HttpPost("LogInUser")]
        public async Task<IActionResult> LogInUserAsync(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _sessionManagementService.LogInUserAsync(loginDto);
            if (result.Succeeded)
            {
                return Ok(loginDto);
            }
            ModelState.AddModelStateErrorList(result.Errors);
            return BadRequest(ModelState);
        }


        [HttpPost("LogOutUser")]
        public async Task<IActionResult> LogOutUserAsync()
        {
            await _sessionManagementService.LogOutUserAsync();
            return Ok();
        }
    }
}
