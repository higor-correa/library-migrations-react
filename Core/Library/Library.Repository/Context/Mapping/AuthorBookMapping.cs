using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.Repository.Context.Mapping
{
    public class AuthorBookMapping : BaseMapping
    {
        public AuthorBookMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            var builder = _modelBuilder.Entity<AuthorBookEntity>();
            
            builder.HasKey(x => new { x.AuthorId, x.BookId });

            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.AuthorId).IsRequired();
            builder.Property(x => x.BookId).IsRequired();

            builder.HasOne(x => x.Author)
                .WithMany(x => x.BooksAuthor)
                .HasForeignKey(x => x.AuthorId);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.AuthorsBook)
                .HasForeignKey(x => x.BookId);

            builder.HasIndex(x => x.BookId);
            builder.HasIndex(x => x.AuthorId);
        }
    }
}
