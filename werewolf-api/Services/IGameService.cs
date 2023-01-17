using werewolf_api.Models;

namespace werewolf_api.Services
{
    public interface IGameService
    {
        public bool DoesSessionExist(string sessionId);
        public string CreateSession(string userId);
    }
}
