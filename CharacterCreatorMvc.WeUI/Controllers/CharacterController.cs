using CharacterCreatorMvc.Application.DTOs;
using CharacterCreatorMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CharacterCreatorMvc.WeUI.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;
        private readonly ICharacterTypeService _characterTypeService;
        private readonly IWebHostEnvironment _environment;
        public CharacterController(ICharacterService characterService, 
            ICharacterTypeService characterTypeService,
            IWebHostEnvironment environment)
        {
            _characterService = characterService;
            _characterTypeService = characterTypeService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var characters = await _characterService.GetCharactersAsync();
            return View(characters);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.CharacterTypeId =
                new SelectList(await _characterTypeService.GetCharacterTypesAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CharacterDTO characterDTO)
        {
            if (ModelState.IsValid)
            {
                await _characterService.AddAsync(characterDTO);
                return RedirectToAction(nameof(Index));
            } else
            {
                ViewBag.CharacterTypeId =
                    new SelectList(await _characterTypeService.GetCharacterTypesAsync(), "Id", "Name");
            }

            return View(characterDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();
            
            var characterDTO = await _characterService.GetCharacterByIdAsync(id);

            if (characterDTO == null)
                return NotFound();

            var characterTypes = await _characterTypeService.GetCharacterTypesAsync();

            ViewBag.CharacterTypeId = new SelectList(characterTypes, "Id", "Name",
                characterDTO.CharacterTypeId);

            return View(characterDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CharacterDTO characterDTO)
        {
            if (ModelState.IsValid)
            {
                await _characterService.UpdateAsync(characterDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(characterDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var characterDTO = await _characterService.GetCharacterByIdAsync(id);

            if (characterDTO == null)
                return NotFound();

            var characterTypes = await _characterTypeService.GetCharacterTypesAsync();

            ViewBag.CharacterTypeId = new SelectList(characterTypes, "Id", "Name",
                characterDTO.CharacterTypeId);

            return View(characterDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _characterService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var characterDTO = await _characterService.GetCharacterByIdAsync(id);

            if (characterDTO == null)
                return NotFound();

            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + characterDTO.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(characterDTO);
        }
    }
}
