using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Core.DTOs;
using ToDoList.Core.Model;
using ToDoList.Core.Services;
using ToDoList.Service.Services;
using ToDoList.Web.Services;

namespace ToDoList.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly UserApiService _userApiService;
        private readonly UserRoleApiService _userRoleApiService;

        public UserController(UserApiService userApiService, UserRoleApiService userRoleApiService)
        {
            _userApiService = userApiService;
            
            _userRoleApiService = userRoleApiService;
        }
        public async Task<IActionResult> Index()
        {
            var userrole = await _userRoleApiService.GetAllAsync();
            var user = await _userApiService.GetUserWithUserRoleAsync();
            ViewBag.userrole = new SelectList(userrole, "Id", "Name");
            return View(user);
        }

        public async Task<IActionResult> Save()
        {
            var userrole = await _userRoleApiService.GetAllAsync();
            ViewBag.userrole = new SelectList(userrole, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userApiService.SaveAsync(userDto); 
                return RedirectToAction(nameof(Index));
            }
            var userrole = await _userRoleApiService.GetAllAsync();
            ViewBag.userrole = new SelectList(userrole, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var user = _userApiService.GetByIdAsync(id);
            var userrole = await _userRoleApiService.GetAllAsync();
            ViewBag.userrole = new SelectList(userrole, "Id", "Name");
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserDto userDto)
        {

            if (ModelState.IsValid)
            {

                await _userApiService.UpdateAsync(userDto);
                return RedirectToAction(nameof(Index));

            }
            var userrole = await _userRoleApiService.GetAllAsync();
            ViewBag.userrole = new SelectList(userrole, "Id", "Name");

            return View(userDto);
        }

        public async Task<IActionResult> Remove(int id)
        {          
            await _userApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
