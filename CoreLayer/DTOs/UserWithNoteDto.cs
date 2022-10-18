namespace ToDoList.Core.DTOs
{
    public class UserWithNoteDto : UserDto
    {
        public List<NoteDto> Notes { get; set; }

    }
}
