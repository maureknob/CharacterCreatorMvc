using CharacterCreatorMvc.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CharacterCreatorMvc.Application.DTOs
{
    public class CharacterDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Health points are required")]
        [Range(1, 999)]
        [DisplayName("Health Points")]
        public int HealthPoints { get; set; }

        [Required(ErrorMessage = "Damage are required")]
        [Range(1, 999)]
        [DisplayName("Damage")]
        public int Damage { get; set; }

        [MaxLength(250)]
        [DisplayName("Character Image")]
        public string Image { get; set; }

        [DisplayName("Character Class")]
        public Guid CharacterTypeId { get; set; }

        [DisplayName("Class")]
        [JsonIgnore]
        public CharacterType? CharacterType { get; set; }
    }
}
