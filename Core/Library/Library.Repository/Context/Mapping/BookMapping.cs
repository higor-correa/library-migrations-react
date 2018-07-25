using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.Repository.Context.Mapping
{
    public class BookMapping : BaseMapping
    {
        public BookMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            var builder = _modelBuilder.Entity<BookEntity>();

            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.Name).IsRequired().HasMaxLength(120);
            builder.Property(x => x.PublishierId);
            builder.Property(x => x.Code).HasMaxLength(10);

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.AuthorsBook)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);

            builder.HasOne(x => x.Publishier)
                .WithMany(x => x.PublishedBooks)
                .HasForeignKey(x => x.PublishierId);

            builder.HasMany(x => x.BookCategories)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
