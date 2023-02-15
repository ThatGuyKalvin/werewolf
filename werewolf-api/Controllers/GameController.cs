using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using werewolf_api.Models;
using werewolf_api.Services;
using werewolf_api.Utilities.Failure;

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
        public IActionResult ValidateSession(string sessionId)
        {
            _logger.LogDebug("Validate session called");
            return _gameService.DoesSessionExist(sessionId) ? Ok() : NotFound();
        }

        [HttpPut]
        [Route("Session")]
        public string JoinSession(string userId, string sessionId)
        {
            return _gameService.JoinSession(userId, sessionId);
        }

        [HttpPost]
        [Route("Session")]
        public string CreateSession(string userId)
        {
            return _gameService.CreateSession(userId);
        }

        [HttpDelete]
        [Authorize]
        [Route("Session")]
        public bool DeleteSession()
        {
            return _gameService.DeleteSession();
        }

        [HttpGet]
        [Authorize]
        [Route("Session/Players")]
        public List<Player> GetPlayers()
        {
            return _gameService.GetPlayers();
        }

    }
}