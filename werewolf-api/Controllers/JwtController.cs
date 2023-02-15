using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using werewolf_api.Models;
using werewolf_api.Services;

namespace werewolf_api.Controllers
{
    [ApiController]
    [Route("Jwt")]
    public class JwtController : ControllerBase
    {
        private readonly ILogger<JwtController> _logger;
        private readonly IJwtService _jwtService;

        public JwtController(ILogger<JwtController> logger, IJwtService jwtService)
        {
            _logger = logger;
            _jwtService = jwtService;
        }

    }
}