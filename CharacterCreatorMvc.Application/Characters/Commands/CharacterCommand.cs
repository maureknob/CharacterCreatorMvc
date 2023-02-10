using CharacterCreatorMvc.Domain.Entities;
using MediatR;

namespace CharacterCreatorMvc.Application.Characters.Commands
{
    public abstract class CharacterCommand : IRequest<Character>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; private set; }
        public int HealthPoints { get; private set; }
        public int Damage { get; private set; }
        public string Image { get; private set; }
        public Guid CharacterTypeId { get; set; }
    }
}
