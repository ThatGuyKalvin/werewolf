using werewolf_api.Models;

namespace werewolf_api.Services
{
    public interface IGameService
    {
        public IEnumerable<Character> GetCharacters();
    }
}
