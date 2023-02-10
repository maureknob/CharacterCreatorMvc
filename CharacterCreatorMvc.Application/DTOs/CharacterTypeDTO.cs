using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreatorMvc.Application.DTOs
{
    public class CharacterTypeDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
