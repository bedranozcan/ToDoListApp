using ToDoList.Core.Model;

namespace ToDoList.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserWithNote(int userId);

        Task<List<User>> GetUserWithUserRole();

    }
}
