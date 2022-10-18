using ToDoList.Core.DTOs;
using ToDoList.Core.Model;

namespace ToDoList.Core.Services
{
    public interface IUserService : IService<User>
    {
        public Task<CustomResponseDto<UserWithNoteDto>> GetUserWithNote(int userId);

        Task<CustomResponseDto<List<UserWithUserRoleDto>>> GetUserWithUserRole();

    }
}
