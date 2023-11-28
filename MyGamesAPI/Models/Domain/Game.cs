namespace MyGamesAPI.Models.Domain
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid StudioId { get; set; }


        // Navigation properties
        public Difficulty Difficulty { get; set; }

        public Studio Studio { get; set; }
    }
}
