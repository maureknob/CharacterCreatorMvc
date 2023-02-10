using CharacterCreatorMvc.Domain.Entities;
using MediatR;

namespace CharacterCreatorMvc.Application.Characters.Commands
{
    public class CharacterRemoveCommand : IRequest<Character>
    {
        public Guid Id { get; set; }
        public CharacterRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
