using Library.Bll.Interfaces;
using Library.Repository.Interfaces;

namespace Library.Bll
{
    public class AuthorBookBll : IAuthorBookBll
    {
        private readonly IAuthorBookRepository _repository;

        public AuthorBookBll(IAuthorBookRepository repository)
        { _repository = repository; }
    }
}
