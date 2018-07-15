using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.Repository.Context.Mapping
{
    public class BookCategoryMapping : BaseMapping
    {
        public BookCategoryMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            var builder = _modelBuilder.Entity<BookCategoryEntity>();

            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.Category).IsRequired();
            builder.Property(x => x.BookId).IsRequired();

            builder.HasKey(x => new { x.BookId, x.Category });

            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookCategories)
                .HasForeignKey(x => x.BookId);

            builder.HasIndex(x => new { x.BookId, x.Category }).IsUnique();
        }
    }
}
