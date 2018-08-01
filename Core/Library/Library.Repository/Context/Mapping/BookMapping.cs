using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context.Mapping
{
    public class BookMapping : BaseMapping<BookEntity>
    {
        public BookMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            _builder.Property(x => x.Name).IsRequired().HasMaxLength(120);
            _builder.Property(x => x.PublishierId);
            _builder.Property(x => x.Code).HasMaxLength(10);

            _builder.HasMany(x => x.AuthorsBook)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);

            _builder.HasOne(x => x.Publishier)
                .WithMany(x => x.PublishedBooks)
                .HasForeignKey(x => x.PublishierId);

            _builder.HasMany(x => x.BookCategories)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
