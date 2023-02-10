using CharacterCreatorMvc.Domain.Entities;
using MediatR;

namespace CharacterCreatorMvc.Application.Characters.Query
{
    public class GetCharactersQuery : IRequest<IEnumerable<Character>>
    {
    }
}
