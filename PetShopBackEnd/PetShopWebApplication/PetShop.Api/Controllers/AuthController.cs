using Microsoft.AspNetCore.Mvc;
using PetShop.Api.DTOs;
using PetShop.Api.Helpers;
using PetShop.Application.Interfaces.Services;

namespace PetShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       private readonly IUserService _userService;
       private readonly JwtTokenGenerator _jwtTokenGenerator;
        
       public AuthController(IUserService userService, JwtTokenGenerator jwtTokenGenerator)
       {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
       }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _userService.Authenticate(dto.Username, dto.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            var token = _jwtTokenGenerator.GenaretaToken(user);

            return Ok(new { Token = token });

        }
    }
}
