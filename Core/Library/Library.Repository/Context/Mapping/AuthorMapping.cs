using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.Repository.Context.Mapping
{
    public class AuthorMapping : BaseMapping
    {
        public AuthorMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            var builder = _modelBuilder.Entity<AuthorEntity>();

            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Code).HasMaxLength(10);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Publishier)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.PublishierId);

            builder.HasMany(a => a.BooksAuthor)
                .WithOne(a => a.Author)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}
