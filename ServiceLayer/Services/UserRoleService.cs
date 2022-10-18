using ToDoList.Core.Model;
using ToDoList.Core.Repositories;
using ToDoList.Core.Services;
using ToDoList.Core.UnitOfWork;

namespace ToDoList.Service.Services
{
    public class UserRoleService : Service<UserRole>, IUserRoleService
    {
        public UserRoleService(IGenericRepository<UserRole> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
