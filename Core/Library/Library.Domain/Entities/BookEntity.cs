﻿using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? PublishierId { get; set; }
        public DateTime? PublishDate { get; set; }

        public PublishierEntity Publishier { get; set; }
        public IList<AuthorBookEntity> AuthorsBook { get; set; }
        public IList<BookCategoryEntity> BookCategories { get; set; }

        public BookEntity()
        {
            AuthorsBook = new List<AuthorBookEntity>();
            BookCategories = new List<BookCategoryEntity>();
        }

        public void Publish(PublishierEntity publisher)
        {
            Publishier = publisher;
            PublishDate = DateTime.Now;
        }

        public void UnPublish()
        {
            Publishier = null;
            PublishDate = null;
        }
    }
}
