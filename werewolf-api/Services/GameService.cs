using System;
using werewolf_api.Models;

namespace werewolf_api.Services
{
    public class GameService : IGameService
    {
        private static Random _random = new Random();
        private IDictionary<string, Session> _sessionsDictionary = new Dictionary<string, Session>();

        public GameService() { }

        public bool DoesSessionExist(string sessionId)
        {
            return _sessionsDictionary.ContainsKey(sessionId);
        }

        public string CreateSession(string userId)
        {
            string randomString;
            do
            {
                randomString = GenerateSessionId();
            } while (_sessionsDictionary.ContainsKey(randomString)) ;

            _sessionsDictionary.Add(randomString, new Session(userId));
            return randomString;
        }


        private static string GenerateSessionId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
