using AutoMapper;
using ToDoList.Core.DTOs;
using ToDoList.Core.Model;

namespace ToDoList.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<User, UserWithNoteDto>();
            CreateMap<User, UserWithUserRoleDto>();
            CreateMap<Note, NoteWithUserDto>();

        }

    }
}
