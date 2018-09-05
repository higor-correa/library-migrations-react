using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;
using System.Linq;

namespace Library.Repository
{
    public class UserRepository : BaseCrudRepository<UserEntity>, IUserRepository
    {
        public UserRepository(LibraryContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<UserEntity> GetForLogin(string login, string password)
        {
            return GetQuery().Where(x => x.Login == login &&
                                    x.Password == password);
        }
    }
}
