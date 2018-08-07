using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context.Mapping
{
    public class PublishierMapping : BaseMapping<PublishierEntity>
    {
        public PublishierMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            _builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            _builder.Property(x => x.Code).HasMaxLength(10);

            _builder.HasMany(x => x.Authors)
                .WithOne(x => x.Publishier)
                .HasForeignKey(x => x.PublishierId);

            _builder.HasMany(x => x.PublishedBooks)
                .WithOne(x => x.Publishier)
                .HasForeignKey(x => x.PublishierId);
        }
    }
}
