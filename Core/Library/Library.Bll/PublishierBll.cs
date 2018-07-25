using Library.Bll.Interfaces;
using Library.Repository.Interfaces;

namespace Library.Bll
{
    public class PublishierBll : IPublishierBll
    {
        private readonly IPublishierRepository _repository;

        public PublishierBll(IPublishierRepository repository)
        { _repository = repository; }
    }
}
