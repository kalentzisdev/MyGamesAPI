using System.ComponentModel.DataAnnotations;

namespace MyGamesAPI.Models.DTO
{
    public class UpdateStudioRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be a minimum of 3 characters")]
        [MaxLength(20, ErrorMessage = "Name has to be a minimum of 20 characters")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Country has to be a minimum of 3 characters")]
        [MaxLength(20, ErrorMessage = "Country has to be a minimum of 20 characters")]
        public string Country { get; set; }
    }
}
