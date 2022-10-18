
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ToDoList.Core.Model;
using ToDoList.Core.Repositories;

namespace ToDoList.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<User> GetUserWithNote(int userId)
        {
            return await _context.Users.Include(x => x.Notes).Where(x => x.Id == userId).SingleOrDefaultAsync();
        }

        public async Task<List<User>> GetUserWithUserRole()
        {
            return await _context.Users.Include(x=>x.UserRole).ToListAsync();
        }
    }
}
