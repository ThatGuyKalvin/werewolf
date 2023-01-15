using werewolf_api.Models;

namespace werewolf_api.Services
{
    public class GameService : IGameService
    {
        private static readonly string[] Names = new[]
        {
            "Kalvin", "Hridai", "Dom"
        };

        public GameService() { }

        public IEnumerable<Character> GetCharacters()
        {
            var characters = new List<Character>();
            foreach (var name in Names)
            {
                characters.Add(new Character(name));
            }
            return characters;
        }

    }
}
