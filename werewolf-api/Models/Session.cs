namespace werewolf_api.Models
{
    public class Session
    {
        public Session(string sessionHostId)
        {
            Players = new List<Player>() { new Player(sessionHostId) };
            SessionHostId = sessionHostId;
        }

        public List<Player> Players { get; set; }
        public string SessionHostId { get; set; }
    }
}
