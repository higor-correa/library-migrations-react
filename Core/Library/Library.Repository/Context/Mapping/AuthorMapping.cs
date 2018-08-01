using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context.Mapping
{
    public class AuthorMapping : BaseMapping<AuthorEntity>
    {
        public AuthorMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Map()
        {
            _builder.Property(x => x.FirstName).IsRequired().HasMaxLength(60);
            _builder.Property(x => x.LastName).IsRequired().HasMaxLength(60);
            _builder.Property(x => x.Code).HasMaxLength(10);
            
            _builder.HasOne(x => x.Publishier)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.PublishierId);

            _builder.HasMany(a => a.BooksAuthor)
                .WithOne(a => a.Author)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}
