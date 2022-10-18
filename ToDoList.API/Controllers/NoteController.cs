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
    public class NoteController : CustomBaseController
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public NoteController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNoteWithUser()
        {

            return CreateActionResult(await _noteService.GetNoteWithUsers());
        }


        [HttpGet]
        public async Task<IActionResult> GetAllNote()
        {
            var note = await _noteService.GetAllAsync();
            var noteDto = _mapper.Map<List<NoteDto>>(note.ToList());
            return CreateActionResult(CustomResponseDto<List<NoteDto>>.Success(200, noteDto));
        }

        [HttpGet("[action]/{noteId}")]
        public async Task<IActionResult> GetNoteWithSingelUser(int noteId)
        {

            return CreateActionResult(await _noteService.GetNoteWithSingleUsers(noteId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteService.GetByIdAsync(id);
            var noteDto = _mapper.Map<NoteDto>(note);
            return CreateActionResult(CustomResponseDto<NoteDto>.Success(200, noteDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(NoteDto noteDto)
        {
            var note = await _noteService.AddAsync(_mapper.Map<Note>(noteDto));
            var noteDtos = _mapper.Map<NoteDto>(note);
            return CreateActionResult(CustomResponseDto<NoteDto>.Success(201, noteDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(NoteDto noteDto)
        {
            await _noteService.UpdateAsync(_mapper.Map<Note>(noteDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _noteService.GetByIdAsync(id);
            await _noteService.RemoveAsync(user);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


    }
}
