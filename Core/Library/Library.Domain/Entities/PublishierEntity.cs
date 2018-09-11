using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class PublishierEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public IList<BookEntity> PublishedBooks { get; set; }
        public IList<AuthorEntity> Authors { get; set; }

        public PublishierEntity()
        {
            PublishedBooks = new List<BookEntity>();
            Authors = new List<AuthorEntity>();
        }
    }
}
