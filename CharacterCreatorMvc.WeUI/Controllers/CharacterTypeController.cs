using CharacterCreatorMvc.Application.DTOs;
using CharacterCreatorMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreatorMvc.WeUI.Controllers
{
    public class CharacterTypeController : Controller
    {
        private readonly ICharacterTypeService _characterTypeService;
        public CharacterTypeController(ICharacterTypeService characterTypeService)
        {
            _characterTypeService = characterTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var characterTypes = await _characterTypeService.GetCharacterTypesAsync();
            return View(characterTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CharacterTypeDTO characterTypeDTO)
        {
            if (ModelState.IsValid)
            {
                await _characterTypeService.AddAsync(characterTypeDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(characterTypeDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var characterTypeDTO = await _characterTypeService.GetCharacterTypeByIdAsync(id);

            if (characterTypeDTO == null)
                return NotFound();

            return View(characterTypeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CharacterTypeDTO characterTypeDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _characterTypeService.UpdateAsync(characterTypeDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(characterTypeDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var characterTypeDTO = await _characterTypeService.GetCharacterTypeByIdAsync(id);

            if (characterTypeDTO == null)
                return NotFound();

            return View(characterTypeDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _characterTypeService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var characterTypeDTO = await _characterTypeService.GetCharacterTypeByIdAsync(id);

            if (characterTypeDTO == null)
                return NotFound();

            return View(characterTypeDTO);
        }

    }
}
