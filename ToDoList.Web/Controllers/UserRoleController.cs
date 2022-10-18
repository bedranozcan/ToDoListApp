using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Core.DTOs;
using ToDoList.Core.Model;
using ToDoList.Core.Services;
using ToDoList.Web.Services;

namespace ToDoList.Web.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly UserRoleApiService _userRoleApiService;

        public UserRoleController(UserRoleApiService userRoleApiService)
        {
            _userRoleApiService = userRoleApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userRoleApiService.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserRoleDto userRoleDto)
        {

            if (ModelState.IsValid)
            {
                await _userRoleApiService.SaveAsync(userRoleDto);
                return RedirectToAction(nameof(Index));
            }       
            return View(userRoleDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var userrole = await _userRoleApiService.GetByIdAsync(id);
            return View(userrole);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserRoleDto userRoleDto)
        {

            if (ModelState.IsValid)
            {
                await _userRoleApiService.UpdateAsync(userRoleDto);
                return RedirectToAction(nameof(Index));
            }
           
            return View(userRoleDto);
        }


        public async Task<IActionResult> Remove(int id)
        {
            await _userRoleApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
