using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? PublishierId { get; set; }

        public PublishierEntity Publishier { get; set; }
        public IList<AuthorBookEntity> AuthorsBook { get; set; }
        public IList<BookCategoryEntity> BookCategories { get; set; }
    }
}
