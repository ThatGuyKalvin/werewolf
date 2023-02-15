using werewolf_api.Models;

namespace werewolf_api.Services
{
    public interface IGameService
    {
        public bool DoesSessionExist(string sessionId);
        public string CreateSession(string userId);
        public string JoinSession(string userId, string sessionId);
        public bool DeleteSession();
        public List<Player> GetPlayers();
    }

    public class GameService : IGameService
    {
        private readonly IJwtService _jwtService;
        private readonly IUserAccessor _userAccessor;

        public GameService(IUserAccessor userAccessor, IJwtService jwtService)
        {
            _userAccessor = userAccessor;
            _jwtService = jwtService;
        }

        private static Random _random = new Random();
        private IDictionary<string, Session> _sessionsDictionary = new Dictionary<string, Session>();


        public bool DoesSessionExist(string sessionId)
        {
            return _sessionsDictionary.ContainsKey(sessionId);
        }

        public string JoinSession(string userId, string sessionId)
        {
            if(DoesSessionExist(sessionId))
            {
                _sessionsDictionary[sessionId].Players.Add(new Player(userId));
                return _jwtService.CreateToken(userId, sessionId);
            }
            return null;
        }

        public string CreateSession(string userId)
        {
            string sessionId;
            do
            {
                sessionId = GenerateSessionId();
            } while (_sessionsDictionary.ContainsKey(sessionId)) ;

            _sessionsDictionary.Add(sessionId, new Session(userId));
            return _jwtService.CreateToken(userId, sessionId);
        }
        public bool DeleteSession()
        {
            return _sessionsDictionary.Remove(_userAccessor.GetSession());
        }

        public List<Player> GetPlayers()
        {
            if(DoesSessionExist(_userAccessor.GetSession())) return _sessionsDictionary[_userAccessor.GetSession()].Players;

            return null;
        }



        private static string GenerateSessionId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
