using Library.Bll.Interfaces;
using Library.Repository.Interfaces;

namespace Library.Bll
{
    public class BookCategoryBll : IBookCategoryBll
    {
        private readonly IBookCategoryRepository _repository;

        public BookCategoryBll(IBookCategoryRepository repository)
        { _repository = repository; }
    }
}
