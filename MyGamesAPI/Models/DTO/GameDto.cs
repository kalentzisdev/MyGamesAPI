namespace MyGamesAPI.Models.DTO
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid StudioId { get; set; }

        public StudioDto Studio { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
