using Microsoft.AspNetCore.Mvc;
using werewolf_api.Models;
using werewolf_api.Services;

namespace werewolf_api.Controllers
{
    [ApiController]
    [Route("Game")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet]
        [Route("Session")]
        public IActionResult GetSession(string sessionId)
        {
            _logger.LogDebug("Validate session called");
            return _gameService.DoesSessionExist(sessionId) ? Ok() : NotFound();
        }

        [HttpPost]
        [Route("Session")]
        public string PostSession(string userId)
        {
            _logger.LogDebug("Create session called");
            return _gameService.CreateSession(userId);
        }
    }
}