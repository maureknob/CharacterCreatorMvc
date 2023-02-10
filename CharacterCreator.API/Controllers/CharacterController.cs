using CharacterCreatorMvc.Application.DTOs;
using CharacterCreatorMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreatorMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> Get()
        {
            var characters = await _characterService.GetCharactersAsync();

            if (characters == null)
                return NotFound();

            return Ok(characters);
        }

        [HttpGet("{id:Guid}", Name = "GetCharacter")]
        public async Task<ActionResult<CharacterDTO>> Get(Guid id)
        {
            var characterType = await _characterService.GetCharacterByIdAsync(id);

            if (characterType == null)
            {
                return NotFound("Type not found");
            }
            return Ok(characterType);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterDTO characterDTO)
        {
            if (characterDTO == null)
                return BadRequest("Invalid Data");

            await _characterService.AddAsync(characterDTO);
            return new CreatedAtRouteResult("GetCharacter", new { id = characterDTO.Id },
                characterDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] CharacterDTO characterDTO)
        {
            if (characterDTO == null)
                return BadRequest();

            if (id != characterDTO.Id)
                return BadRequest();

            await _characterService.UpdateAsync(characterDTO);

            return Ok(characterDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<CharacterDTO>> Delete(Guid id)
        {
            var characterType = await _characterService.GetCharacterByIdAsync(id);
            if (characterType == null)
                return NotFound();

            await _characterService.RemoveAsync(characterType.Id);

            return Ok(characterType);
        }
    }
}
