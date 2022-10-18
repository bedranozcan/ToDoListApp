using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.DTOs;
using ToDoList.Core.Model;
using ToDoList.Core.Services;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : CustomBaseController
    {
        private readonly IUserRoleService _roleService;
        private readonly IMapper _mapper;
        public UserRoleController(IUserRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserRole()
        {
            var userrole = await _roleService.GetAllAsync();
            var userRoleDtos = _mapper.Map<List<UserRoleDto>>(userrole.ToList());
            return CreateActionResult(CustomResponseDto<List<UserRoleDto>>.Success(200, userRoleDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userrole = await _roleService.GetByIdAsync(id);
            var userRoleDto = _mapper.Map<UserRoleDto>(userrole);
            return CreateActionResult(CustomResponseDto<UserRoleDto>.Success(200, userRoleDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserRoleDto userRoleDto)
        {
            var userrole = await _roleService.AddAsync(_mapper.Map<UserRole>(userRoleDto));
            var userRoleDtos = _mapper.Map<UserRoleDto>(userrole);
            return CreateActionResult(CustomResponseDto<UserRoleDto>.Success(201, userRoleDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserRoleDto userRoleDto)
        {
            await _roleService.UpdateAsync(_mapper.Map<UserRole>(userRoleDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var userrole = await _roleService.GetByIdAsync(id);
            await _roleService.RemoveAsync(userrole);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }




    }
}
