using System.ComponentModel.DataAnnotations;

namespace MyGamesAPI.Models.DTO
{
    public class AddGameRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be a minimum of 3 characters")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Type has to be a minimum of 3 characters")]
        public string Type { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "Value should be double")]
        public double Price { get; set; }

        public string ImageURL { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid StudioId { get; set; }
    }
}
