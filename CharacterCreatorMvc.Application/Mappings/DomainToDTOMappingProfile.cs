using AutoMapper;
using CharacterCreatorMvc.Application.DTOs;
using CharacterCreatorMvc.Domain.Entities;

namespace CharacterCreatorMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Character, CharacterDTO>().ReverseMap();
            CreateMap<CharacterType, CharacterTypeDTO>().ReverseMap();
        }
    }
}