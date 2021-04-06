namespace Hqv.Dominoes.WebApplication.Events
{
    public class Player
    {
        public Player(string id, string name, string? ipAddress)
        {
            Id = id;
            Name = name;
            IpAddress = ipAddress;
        }

        public string Id { get; }
        public string Name { get; }
        public string? IpAddress { get; }
    }
}