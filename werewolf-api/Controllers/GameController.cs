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
        [Route("GetCharacters")]
        public IEnumerable<Character> GetCharacters()
        {
            _logger.LogDebug("GetCharacters called");
            return _gameService.GetCharacters();
        }
    }
}