using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Core.DTOs;
using ToDoList.Core.Model;
using ToDoList.Web.Services;

namespace ToDoList.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly UserApiService _userApiService;
        private readonly NoteApiService _noteApiService;

        public NoteController(NoteApiService noteApiService, UserApiService userApiService)
        {
            _noteApiService = noteApiService;
            _userApiService = userApiService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _noteApiService.GetAllNoteWithUsers());
        }
        public async Task<IActionResult> Save()
        {
            var users= await _userApiService.GetAllAsync();
            ViewBag.users = new SelectList(users, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(NoteDto noteDto)
        {
            if (ModelState.IsValid)
            {

                await _noteApiService.SaveAsync(noteDto);
                return RedirectToAction(nameof(Index));
            }
            var users = await _userApiService.GetAllAsync();
            ViewBag.users = new SelectList(users, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var notes= await _noteApiService.GetByIdAsync(id);
            var users = await _userApiService.GetAllAsync();
            ViewBag.users = new SelectList(users, "Id", "Name");
            return View(notes);
        }
        [HttpPost]
        public async Task<IActionResult> Update(NoteDto noteDto)
        {
            if (ModelState.IsValid)
            {
                await _noteApiService.UpdateAsync(noteDto);
                return RedirectToAction(nameof(Index));
            }
            var users = await _userApiService.GetAllAsync();
            ViewBag.users = new SelectList(users, "Id", "Name");
            return View(noteDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _noteApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
