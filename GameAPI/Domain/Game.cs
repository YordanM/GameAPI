namespace GameAPI.Domain
{
    public class Game
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Region { get; set; }
        public decimal? Price { get; set; }
    }
}
