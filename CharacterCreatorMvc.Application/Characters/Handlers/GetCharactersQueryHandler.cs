using CharacterCreatorMvc.Application.Characters.Query;
using CharacterCreatorMvc.Domain.Entities;
using CharacterCreatorMvc.Domain.Interfaces;
using MediatR;

namespace CharacterCreatorMvc.Application.Characters.Handlers
{
    public class GetCharactersQueryHandler : IRequestHandler<GetCharactersQuery, IEnumerable<Character>>
    {
        private readonly ICharacterRepository _characterRepository;
        public GetCharactersQueryHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<IEnumerable<Character>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
        {
            return await _characterRepository.GetCharactersAsync();
        }
    }
}
