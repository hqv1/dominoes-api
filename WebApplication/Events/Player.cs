namespace Hqv.Dominoes.WebApplication.Events
{
    public class Player
    {
        public Player(string name, string? ipAddress)
        {
            Name = name;
            IpAddress = ipAddress;
        }
        
        public string Name { get; }
        public string? IpAddress { get; }
    }
}