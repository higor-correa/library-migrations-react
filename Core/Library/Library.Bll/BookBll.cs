using Library.Bll.Interfaces;
using Library.Repository.Interfaces;

namespace Library.Bll
{
    public class BookBll : IBookBll
    {
        private readonly IBookRepository _repository;

        public BookBll(IBookRepository repository)
        { _repository = repository; }
    }
}
