using AutoMapper;
using CharacterCreatorMvc.Application.Characters.Commands;
using CharacterCreatorMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorMvc.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<CharacterDTO, CharacterCreateCommand>();
            CreateMap<CharacterDTO, CharacterUpdateCommand>();
        }
    }
}
