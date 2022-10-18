using AutoMapper;
using ToDoList.Core.DTOs;
using ToDoList.Core.Model;
using ToDoList.Core.Repositories;
using ToDoList.Core.Services;
using ToDoList.Core.UnitOfWork;
using ToDoList.Repository.Repositories;

namespace ToDoList.Service.Services
{
    public class NoteService : Service<Note>, INoteService
    {
        private INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public NoteService(IGenericRepository<Note> repository, IUnitOfWork unitOfWork, INoteRepository noteRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }


        public async Task<CustomResponseDto<NoteWithUserDto>> GetNoteWithSingleUsers(int noteId)
        {
            var notes = await _noteRepository.GetNoteWithSingleUser(noteId);
            var noteDtos = _mapper.Map<NoteWithUserDto>(notes);
            return CustomResponseDto<NoteWithUserDto>.Success(200, noteDtos);
        }

        public async Task<CustomResponseDto<List<NoteWithUserDto>>> GetNoteWithUsers()
        {
            var notes = await _noteRepository.GetAllNoteWithUsers();
            var noteDtos = _mapper.Map<List<NoteWithUserDto>>(notes);
            return CustomResponseDto<List<NoteWithUserDto>>.Success(200, noteDtos);
        }
    }
}
