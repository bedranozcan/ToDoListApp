using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.DTOs;
using ToDoList.Core.Model;
using ToDoList.Core.Services;
using ToDoList.Service.Services;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserWithUserRole()
        {

            return CreateActionResult(await _userService.GetUserWithUserRole());
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await _userService.GetAllAsync();
            var userDtos = _mapper.Map<List<UserDto>>(user.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, userDtos));
        }


        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetUserWithNote(int userId)
        {

            return CreateActionResult(await _userService.GetUserWithNote(userId));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = await _userService.AddAsync(_mapper.Map<User>(userDto));
            var userDtos = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, userDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(userDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            await _userService.RemoveAsync(user);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }



    }
}
