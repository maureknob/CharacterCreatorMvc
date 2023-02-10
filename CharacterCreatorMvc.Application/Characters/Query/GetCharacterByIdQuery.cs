using CharacterCreatorMvc.Domain.Entities;
using MediatR;

namespace CharacterCreatorMvc.Application.Characters.Query
{
    public class GetCharacterByIdQuery : IRequest<Character>
    {
        public Guid Id { get; set; }
        public GetCharacterByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
