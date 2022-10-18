
using RepositoryLayer;
using ToDoList.Core.Model;
using ToDoList.Core.Repositories;

namespace ToDoList.Repository.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
