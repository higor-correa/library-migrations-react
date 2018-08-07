using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context.Mapping
{
    public class BookCategoryMapping : BaseMapping<BookCategoryEntity>
    {
        public BookCategoryMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            _builder.HasKey(x => new { x.BookId, x.Category });

            _builder.Property(x => x.Category).IsRequired();
            _builder.Property(x => x.BookId).IsRequired();

            _builder.HasOne(x => x.Book)
                .WithMany(x => x.BookCategories)
                .HasForeignKey(x => x.BookId);

            _builder.HasIndex(x => new { x.BookId, x.Category }).IsUnique();
        }
    }
}
