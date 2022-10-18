using ToDoList.Core.Model;

namespace ToDoList.Core.Repositories
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        Task<Note> GetNoteWithSingleUser(int noteId);
        Task<List<Note>> GetAllNoteWithUsers();

      
    }
}
