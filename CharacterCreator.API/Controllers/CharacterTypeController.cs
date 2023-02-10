using CharacterCreatorMvc.Application.DTOs;
using CharacterCreatorMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreatorMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CharacterTypeController : ControllerBase
    {
        private readonly ICharacterTypeService _characterTypeService;

        public CharacterTypeController(ICharacterTypeService characterTypeService)
        {
            _characterTypeService = characterTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterTypeDTO>>> Get()
        {
            var characterTypes = await _characterTypeService.GetCharacterTypesAsync();
            if(characterTypes == null)
            {
                return NotFound("Types not found");
            }
            return Ok(characterTypes);
        }

        [HttpGet("{id:Guid}", Name = "GetTypes")]
        public async Task<ActionResult<CharacterTypeDTO>> Get(Guid id)
        {
            var characterType = await _characterTypeService.GetCharacterTypeByIdAsync(id);

            if (characterType == null)
            {
                return NotFound("Type not found");
            }
            return Ok(characterType);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterTypeDTO characterTypeDTO)
        {
            if (characterTypeDTO == null)
                return BadRequest("Invalid Data");

            await _characterTypeService.AddAsync(characterTypeDTO);
            return new CreatedAtRouteResult("GetTypes", new { id = characterTypeDTO.Id},
                characterTypeDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] CharacterTypeDTO characterTypeDTO)
        {
            if(characterTypeDTO == null)
                return BadRequest();

            if (id != characterTypeDTO.Id)
                return BadRequest();

            await _characterTypeService.UpdateAsync(characterTypeDTO);

            return Ok(characterTypeDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<CharacterTypeDTO>> Delete(Guid id)
        {
            var characterType = await _characterTypeService.GetCharacterTypeByIdAsync(id);
            if (characterType == null)
                return NotFound();

            await _characterTypeService.RemoveAsync(characterType.Id);

            return Ok(characterType);
        }
    }
}
