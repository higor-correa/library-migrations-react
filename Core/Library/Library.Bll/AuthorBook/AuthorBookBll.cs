using Library.Bll.AuthorBook.Interfaces;
using Library.Repository.Interfaces;

namespace Library.Bll.AuthorBook
{
    public class AuthorBookBll : IAuthorBookBll
    {
        private readonly IAuthorBookRepository _repository;

        public AuthorBookBll(IAuthorBookRepository repository)
        { _repository = repository; }
    }
}
