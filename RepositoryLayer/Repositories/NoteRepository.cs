
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ToDoList.Core.Model;
using ToDoList.Core.Repositories;

namespace ToDoList.Repository.Repositories
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Note>> GetAllNoteWithUsers()
        {
           return await _context.Notes.Include(x=>x.User).ToListAsync();
        }

        public async Task<Note> GetNoteWithSingleUser(int noteId)
        {
            return await _context.Notes.Include(x => x.User).Where(x => x.Id == noteId).SingleOrDefaultAsync();

        }
    }
}
