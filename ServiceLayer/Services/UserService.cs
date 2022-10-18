using AutoMapper;
using ToDoList.Core.DTOs;
using ToDoList.Core.Model;
using ToDoList.Core.Repositories;
using ToDoList.Core.Services;
using ToDoList.Core.UnitOfWork;
using ToDoList.Repository.Repositories;

namespace ToDoList.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

       
        public async Task<CustomResponseDto<UserWithNoteDto>> GetUserWithNote(int userId)
        {
            var user = await _userRepository.GetUserWithNote(userId);
            var userDtos = _mapper.Map<UserWithNoteDto>(user);
            return CustomResponseDto<UserWithNoteDto>.Success(200, userDtos);
        }

        public async Task<CustomResponseDto<List<UserWithUserRoleDto>>> GetUserWithUserRole()
        {
            var users = await _userRepository.GetUserWithUserRole();
            var userDtos = _mapper.Map<List<UserWithUserRoleDto>>(users);
            return CustomResponseDto<List<UserWithUserRoleDto>>.Success(200, userDtos);
        }
    }
}
