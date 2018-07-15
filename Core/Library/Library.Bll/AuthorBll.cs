using Library.Bll.Interfaces;
using Library.Repository.Interfaces;

namespace Library.Bll
{
    public class AuthorBll : IAuthorBll
    {
        private readonly IAuthorRepository _repository;

        public AuthorBll(IAuthorRepository repository)
        { _repository = repository; }

    }
}
