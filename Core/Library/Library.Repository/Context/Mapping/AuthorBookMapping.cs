using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context.Mapping
{
    public class AuthorBookMapping : BaseMapping<AuthorBookEntity>
    {
        public AuthorBookMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            _builder.HasKey(x => new { x.AuthorId, x.BookId });

            _builder.Property(x => x.AuthorId).IsRequired();
            _builder.Property(x => x.BookId).IsRequired();

            _builder.HasOne(x => x.Author)
                .WithMany(x => x.BooksAuthor)
                .HasForeignKey(x => x.AuthorId);

            _builder.HasOne(x => x.Book)
                .WithMany(x => x.AuthorsBook)
                .HasForeignKey(x => x.BookId);

            _builder.HasIndex(x => x.BookId);
            _builder.HasIndex(x => x.AuthorId);
        }
    }
}
