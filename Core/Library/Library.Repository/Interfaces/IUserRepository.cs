using Library.Domain.Entities;
using System.Linq;

namespace Library.Repository.Interfaces
{
    public interface IUserRepository : ICrudRepository<UserEntity>
    {
        IQueryable<UserEntity> GetForLogin(string login, string password);
    }
}
