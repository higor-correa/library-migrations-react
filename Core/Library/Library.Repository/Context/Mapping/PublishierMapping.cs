using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.Repository.Context.Mapping
{
    public class PublishierMapping : BaseMapping
    {
        public PublishierMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            var builder = _modelBuilder.Entity<PublishierEntity>();

            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Code).HasMaxLength(10);

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Authors)
                .WithOne(x => x.Publishier)
                .HasForeignKey(x => x.PublishierId);

            builder.HasMany(x => x.PublishedBooks)
                .WithOne(x => x.Publishier)
                .HasForeignKey(x => x.PublishierId);
        }
    }
}
