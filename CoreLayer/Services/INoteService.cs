using ToDoList.Core.DTOs;
using ToDoList.Core.Model;

namespace ToDoList.Core.Services
{
    public interface INoteService : IService<Note>
    {
        Task<CustomResponseDto<List<NoteWithUserDto>>> GetNoteWithUsers();
        public Task<CustomResponseDto<NoteWithUserDto>> GetNoteWithSingleUsers(int noteId);


    }
}
